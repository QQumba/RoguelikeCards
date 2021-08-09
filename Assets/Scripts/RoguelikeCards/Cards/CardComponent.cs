using System;
using RoguelikeCards.Heroes;
using UnityEngine;

namespace RoguelikeCards.Cards
{
    [Serializable]
    public abstract class CardComponent : MonoBehaviour
    {
        public Card Card => GetComponent<CardContent>().Card;
        public abstract void Accept(ICardComponentVisitor visitor);
    }
}