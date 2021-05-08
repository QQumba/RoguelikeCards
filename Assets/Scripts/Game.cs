using System;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using DefaultNamespace.Powerups;
using UnityEngine;
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
            
            Destroy(card.gameObject);
        }

        public void SwapCards(Card from, Card to)
        {
            var fromIndex = this.GetGameCardIndex(from);
            var toIndex = this.GetGameCardIndex(to);
            
            Cards[fromIndex] = to;
            Cards[toIndex] = from;
        }

        public void MoveHero(Card card)
        {
            int heroIndex = this.GetGameCardIndex(Hero);
            int cardIndex = this.GetGameCardIndex(card);

            Cards[cardIndex] = Hero;
            RemoveCard(card);
            
            GenerateCard(heroIndex);
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
        }

        public void UpdateCardsPosition()
        {
            foreach (var card in Cards)
            {
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
                    // card = Instantiate(AllPowerups[Random.Range(0, AllPowerups.Length)], Vector3.zero, Quaternion.identity);
                    card = CardGenerator.GenerateCard();
                }
                
                card.Game = this;
                GameState.Cards[i] = card;
                
                card.transform.position = this.GetCardPosition(GameState.Cards[i]);
            }
        }
    }
}