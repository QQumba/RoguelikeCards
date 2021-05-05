using System;
using System.Collections.Generic;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using DefaultNamespace.Powerups;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        private int _sideSize;
        private readonly CardFactory _cardFactory;

        public Powerup[] AllPowerups;
        public Enemy[] AllEnemies;

        public int SideSize = 3;

        private void Start()
        {
            Cards = new Card[SideSize * SideSize];
            _sideSize = SideSize;
            
            GenerateCards(_sideSize);
        }

        private void Update()
        {
            
        }

        public Game(int sideSize, CardFactory cardFactory)
        {
            Cards = new Card[sideSize * SideSize];
            _sideSize = sideSize;
            _cardFactory = cardFactory;

            GenerateCards(sideSize);
        }

        public Hero Hero;

        public Card[] Cards { get; private set; }

        public int TurnCount { get; } = 0;

        public List<Enemy> Enemies
        {
            get
            {
                var enemies = new List<Enemy>();
                foreach (var card in Cards)
                {
                    if (card is Enemy enemy)
                    {
                        enemies.Add(enemy);
                    }
                }

                return enemies;
            }
        }

        public List<Powerup> Powerups
        {
            get
            {
                var powerups = new List<Powerup>();
                foreach (var card in Cards)
                {
                    if (card is Powerup powerup)
                    {
                        powerups.Add(powerup);
                    }
                }

                return powerups;
            }
        }

        public void Stop()
        {
            Debug.Log("GAME OVER");
        }

        public Vector2 GetCardPosition(Card card)
        {
            var index = GetGameCardIndex(card);
            return GetCardPosition(index);
        }
        
        public Vector2 GetCardPosition(int cardIndex)
        {
            var position = new Vector2(cardIndex % _sideSize, (int)(cardIndex / _sideSize));
            return position;
        }

        public void RemoveCard(Card card)
        {
            var index = GetGameCardIndex(card);
            if (card == Hero) return;
            
            Cards[index] = _cardFactory.GetCard();
        }

        //TODO handle exceptions in navigation methods if given card not in _cards
        //Game field presented as array of cards.
        //Card presented as square field with side size of _sideSize
        //Example:
        // 6 7 8             6  bottom        8
        // 3 4 5          left    card    right
        // 0 1 2             0     top        2
        public Card Top(Card card)
        {
            var currentCardIndex = GetGameCardIndex(card);
            Debug.Log($"clicked card index: {currentCardIndex}");
            Debug.Log($"top card index: {currentCardIndex}");
            var index = currentCardIndex + _sideSize;
            return IsCardIndexInbound(index) ? Cards[index] : null;
        }

        public Card Bottom(Card card)
        {
            var currentCardIndex = GetGameCardIndex(card);
            var index = currentCardIndex - _sideSize;
            return IsCardIndexInbound(index) ? Cards[index] : null;
        }
        
        public Card Left(Card card)
        {
            var currentCardIndex = GetGameCardIndex(card);
            if (currentCardIndex % _sideSize == 0)
            {
                return null;
            }
            var index = currentCardIndex - 1;
            return IsCardIndexInbound(index) ? Cards[index] : null;
        }
        
        public Card Right(Card card)
        {
            var currentCardIndex = GetGameCardIndex(card);
            var index = currentCardIndex + 1;
            if (index % _sideSize == 0)
            {
                return null;
            }
            return IsCardIndexInbound(index) ? Cards[index] : null;
        }

        public void SwapCards(Card from, Card to)
        {
            Debug.Log($"swap cards");

            var fromIndex = GetGameCardIndex(from);
            var toIndex = GetGameCardIndex(to);

            var position = from.transform.position; 
            from.transform.position = to.transform.position;
            to.transform.position = position;
            
            Cards[fromIndex] = to;
            Cards[toIndex] = from;
        }

        private bool IsCardIndexInbound(int index)
        {
            return index >= 0 && index < Cards.Length;
        }

        public int GetGameCardIndex(Card card)
        {
            var index = Array.IndexOf(Cards, card);
            if (index == -1) throw new InvalidCardException();
            return index;
        } 

        private void GenerateCards(int size)
        {
            size *= size;
            var playerPosition = Random.Range(0, size);
            Debug.Log($"[Game] player index: {playerPosition}");
            for (int i = 0; i < size; i++)
            {
                Card card;
                if (i == playerPosition)
                {
                    card = Instantiate(Hero, Vector3.zero, Quaternion.identity);
                    Hero = card as Hero;
                }
                else
                {
                    card = Instantiate(AllPowerups[Random.Range(0, AllPowerups.Length)], Vector3.zero, Quaternion.identity);
                }
                
                card.Game = this;
                Cards[i] = card;
                card.transform.position = GetCardPosition(Cards[i]);
            }
        }

        private void AddFactories()
        {
            _cardFactory.AddFactory(
                new PowerupFactory(this, AllPowerups, 50));
        }
    }
}