using System.Linq;
using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private CardContent hero;
        [SerializeField] private CardContent[] contents;

        public Card SpawnCard(Vector2 position)
        {
            return SpawnCard(position, contents[Random.Range(0, contents.Length)]);
        }

        public Card SpawnHero(Vector2 position)
        {
            return SpawnCard(position, hero);
        }

        private Card SpawnCard(Vector2 position, CardContent contentPrefab)
        {
            var card = Instantiate(cardPrefab, position, Quaternion.identity);
            card.transform.position = position;
            card.Content = contentPrefab.GetInstance(card);
            return card;
        }
    }
}