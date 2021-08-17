using System;
using System.Collections.Generic;
using RoguelikeCards.Cards;
using RoguelikeCards.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoguelikeCards
{
    [RequireComponent(typeof(GameFieldNavigator))]
    [RequireComponent(typeof(CardSpawner))]
    public class GameField : MonoBehaviour
    {
        [SerializeField] private int sideSize;

        private GameFieldNavigator _navigator;
        private CardSpawner _spawner;

        public event Action GameFieldInitialized;
        public event Action<Card> CardSpawned;

        public Card[] Cards { get; private set; }

        private void Awake()
        {
            _spawner = GetComponent<CardSpawner>();
            _navigator = GetComponent<GameFieldNavigator>();
            Cards = new Card[sideSize * sideSize];
        }

        private void Start()
        {
            InitializeGameField();
            GameFieldInitialized?.Invoke();
        }

        public List<TComponent> GetCardComponents<TComponent>()
        {
            var cards = new List<TComponent>();
            foreach (var card in Cards)
            {
                foreach (var component in card.Content.CardComponents)
                {
                    if (component is TComponent c)
                    {
                        cards.Add(c);
                    }
                }
            }

            return cards;
        }

        public void MoveCard(Card from, Card to)
        {
            var fromIndex = Cards.GetCardIndex(from);
            var toIndex = Cards.GetCardIndex(to);

            if (IsCardIndexInbound(fromIndex) == false)
            {
                return;
            }

            var card = Cards[fromIndex];

            Cards[toIndex] = card;
            Cards[fromIndex] = null;
        }

        private bool IsCardIndexInbound(int index)
        {
            return index >= 0 && index < Cards.Length;
        }

        public void ReplaceCard(Card card)
        {
            var index = Cards.GetCardIndex(card);
            ReplaceCard(index);
        }
        
        public void ReplaceCard(int index)
        {
            Cards[index] = _spawner.SpawnCard(Cards.GetCardPosition(index));
        }

        private void InitializeGameField()
        {
            var heroIndex = Random.Range(0, Cards.Length);

            for (int i = 0; i < Cards.Length; i++)
            {
                // (i % sideSize) = "x" coord on game field
                // (i / sideSize) = "y" coord on game field
                var position = new Vector2(i % sideSize, (int) (i / sideSize));
                var card = i == heroIndex ? _spawner.SpawnHero(position) : _spawner.SpawnCard(position);

                // TODO: ???
                card.Navigator = _navigator;
                CardSpawned?.Invoke(card);
                Cards[i] = card;
            }
        }
    }
}