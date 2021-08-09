using UnityEngine;

namespace RoguelikeCards.Cards
{
    public class CardContent : MonoBehaviour
    {
        public CardComponent[] CardComponents => GetComponents<CardComponent>();
        public Card Card { get; set; }
    }
}