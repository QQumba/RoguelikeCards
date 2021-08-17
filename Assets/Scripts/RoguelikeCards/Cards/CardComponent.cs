using RoguelikeCards.Heroes;
using UnityEngine;

namespace RoguelikeCards.Cards
{
    [RequireComponent(typeof(CardContent))]
    public abstract class CardComponent : MonoBehaviour
    {
        private Card _card;
        
        public Card Card => _card ??= GetComponent<CardContent>().Card;
        public abstract void Accept(ICardComponentVisitor visitor);
    }
}