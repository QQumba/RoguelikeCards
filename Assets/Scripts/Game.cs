using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using DefaultNamespace.Powerups;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public GameState GameState;
        public Hero Hero;
        public CardGenerator CardGenerator;
        
        public int SideSize => GameState.SideSize;
        public Card[] Cards => GameState.Cards;
        public int TurnCount { get; } = 0;
        
        private void Start()
        {
            InitializeGameField();
            Debug.Log("Game initialized");
        }

        public void Stop()
        {
            Debug.Log("GAME OVER");
        }
        
        public void RemoveCard(Card card)
        {
            if (card == Hero)
            {
                Debug.Log("Game.RemoveCard -> trying to remove hero.");
                return;
            }
            
            var index = this.GetGameCardIndex(card);
            Cards[index] = null;
            
            card.Remove();
        }

        public void SwapCards(Card from, Card to)
        {
            var fromIndex = this.GetGameCardIndex(from);
            var toIndex = this.GetGameCardIndex(to);
            
            Cards[fromIndex] = to;
            Cards[toIndex] = from;
        }

        public void MoveCard(int fromIndex, int toIndex)
        {
            if (!this.IsCardIndexInbound(fromIndex))
            {
                return;
            }
            if (Cards[toIndex] != null)
            {
                Debug.Log($"Game.MoveCard -> can't move card from index [{fromIndex}] to index [{toIndex}]. Trying to move card to existing card.");
                return;
            }

            var card = Cards[fromIndex];
            
            Cards[toIndex] = card;
            Cards[fromIndex] = null;
            card.Move(this.GetCardPosition(fromIndex), this.GetCardPosition(toIndex));   
            // UpdateCardsPosition();
        }

        public void ShiftCards(int index)
        {
            var counts = new[]
            {
                GetTopCardsCount(index),
                GetRightCardsCount(index),
                GetBottomCardsCount(index),
                GetLeftCardsCount(index)
            };

            if (counts[0] == counts.Max())
            {
                Debug.Log($"Max card on top: {counts.Max()}");
                ShiftBottom(index);
                return;
            }
            if (counts[1] == counts.Max())
            {
                Debug.Log($"Max card on right: {counts.Max()}");
                ShiftLeft(index);
                return;
            }
            if (counts[2] == counts.Max())
            {
                Debug.Log($"Max card on bottom: {counts.Max()}");
                ShiftTop(index);
                return;
            }
            if (counts[3] == counts.Max())
            {
                Debug.Log($"Max card on left: {counts.Max()}");
                ShiftRight(index);
                return;
            }
        }

        public int GetTopCardsCount(int index)
        {
            var edgeIndex = SideSize * (SideSize - 1) + (index % SideSize);
            for (int i = index; i <= edgeIndex; i += SideSize)
            {
                if (Cards[i] == Hero)
                {
                    return 0;
                }
            }

            return (edgeIndex - index) / SideSize;
        }

        public int GetBottomCardsCount(int index)
        {
            var edgeIndex = index % SideSize;
            for (int i = index; i >= edgeIndex; i -= SideSize)
            {
                if (Cards[i] == Hero)
                {
                    return 0;
                }
            }

            return (index - edgeIndex) / SideSize;
        }

        public int GetRightCardsCount(int index)
        {
            var edgeIndex = index + SideSize - 1 - index % SideSize;
            for (int i = index; i <= edgeIndex; i++)
            {
                if (Cards[i] == Hero)
                {
                    return 0;
                }
            }

            return edgeIndex - index;
        }

        public int GetLeftCardsCount(int index)
        {
            var edgeIndex = index / SideSize * SideSize;
            for (int i = index; i >= edgeIndex; i--)
            {
                if (Cards[i] == Hero)
                {
                    return 0;
                }
            }

            return index - edgeIndex;
        }
        
        public void ShiftTop(int index)
        {
            var edgeIndex = index % SideSize;
            for (int i = index; i >= edgeIndex; i -= SideSize)
            {
                if (i == edgeIndex)
                {
                    GenerateCard(i);
                    return;
                }
                MoveCard(i - SideSize, i);
            }
        }
        
        public void ShiftBottom(int index)
        {
            var edgeIndex = SideSize * (SideSize - 1) + (index % SideSize);
            for (int i = index; i <= edgeIndex; i += SideSize)
            {
                if (i == edgeIndex)
                {
                    GenerateCard(i);
                    return;
                }
                MoveCard(i + SideSize, i);
            }
        }
        
        public void ShiftRight(int index)
        {
            var edgeIndex = index / SideSize * SideSize;
            for (int i = index; i >= edgeIndex; i--)
            {
                if (i == edgeIndex)
                {
                    GenerateCard(i);
                    return;
                }
                MoveCard(i - 1, i);
            }
        }
        
        // 6 7 8 
        // 3 4 5 
        // 0 1 2 
        
        public void ShiftLeft(int index)
        {
            var edgeIndex = index + SideSize - 1 - index % SideSize;
            for (int i = index; i <= edgeIndex; i++)
            {
                if (i == edgeIndex)
                {
                    GenerateCard(i);
                    return;
                }
                MoveCard(i + 1, i);
            }
        }

        public void MoveHero(Card card)
        {
            int heroIndex = this.GetGameCardIndex(Hero);
            int cardIndex = this.GetGameCardIndex(card);

            RemoveCard(card);
            Cards[cardIndex] = Hero;
            Cards[heroIndex] = null;
            
            // GenerateCard(heroIndex);
            ShiftCards(heroIndex);
            Hero.Move(this.GetCardPosition(heroIndex), this.GetCardPosition(cardIndex));
        }

        public void ReplaceCard(Card source, Card destination)
        {
            var destinationIndex = this.GetGameCardIndex(destination);

            var card = Instantiate(source, Vector3.zero, Quaternion.identity);
            RemoveCard(destination);
            
            card.Game = this;
            Cards[destinationIndex] = card;
            
            
            UpdateCardsPosition();
        }

        public void GenerateCard(int index)
        {
            if (Cards[index] != null)
            {
                Debug.Log($"Game.GenerateCard -> can't generate card on index: {index}, card on this index already exist.");
                return;
            }
            
            var card = CardGenerator.GenerateCard();
            Cards[index] = card;
            card.AssignToGame(this);
        }

        public void UpdateCardsPosition()
        {
            foreach (var card in Cards)
            {
                if (card == null)
                {
                    continue;
                }

                card.transform.position = this.GetCardPosition(card);
            }
        }

        private void InitializeGameField()
        {
            var playerPosition = Random.Range(0, SideSize * SideSize);
            for (int i = 0; i < SideSize * SideSize; i++)
            {
                Card card;
                if (i == playerPosition)
                {
                    card = Instantiate(Hero, Vector3.zero, Quaternion.identity);
                    Hero = (Hero) card;
                }
                else
                {
                    card = CardGenerator.GenerateCard();
                }
                
                GameState.Cards[i] = card;
                card.AssignToGame(this);
                
                //card.transform.position = this.GetCardPosition(GameState.Cards[i]);
            }
        }
    }
}