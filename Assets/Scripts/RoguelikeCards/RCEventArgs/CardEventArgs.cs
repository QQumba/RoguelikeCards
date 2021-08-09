using System;
using RoguelikeCards.Cards;

namespace RoguelikeCards.RCEventArgs
{
    public class CardEventArgs : EventArgs
    {
        public CardEventArgs(Card card)
        {
            Card = card;
        }

        public Card Card { get; }

        public static implicit operator CardEventArgs(Card card) => new CardEventArgs(card);
    }
}