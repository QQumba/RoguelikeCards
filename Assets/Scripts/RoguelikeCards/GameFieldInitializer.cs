using System;
using RoguelikeCards.Cards;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoguelikeCards
{
    [RequireComponent(typeof(CardSpawner))]
    public class GameFieldInitializer : MonoBehaviour
    {
        private CardSpawner _spawner;

        public event Action<Card> CardSpawned;

        private void Awake()
        {
            _spawner = GetComponent<CardSpawner>();
        }

        /// <summary>
        /// Initialize square game field
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="sideSize"></param>
        public void InitializeGameField(Card[] cards)
        {
            var sideSize = (int) Mathf.Sqrt(cards.Length);
            if (sideSize * sideSize != cards.Length)
                throw new ArgumentException($"Square root of {nameof(cards)}.Lenght should be an integer");

            var heroIndex = Random.Range(0, cards.Length);

            for (int i = 0; i < cards.Length; i++)
            {
                // (i % sideSize) = "x" coord on game field
                // (i / sideSize) = "y" coord on game field
                var position = new Vector2(i % sideSize, (int) (i / sideSize));
                var card = i == heroIndex ? _spawner.SpawnHero(position) : _spawner.SpawnCard(position);
                CardSpawned?.Invoke(card);
                cards[i] = card;    
            }
        }
    }
}