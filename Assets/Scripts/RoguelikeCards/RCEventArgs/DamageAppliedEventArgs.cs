using System;
using RoguelikeCards.Cards;

namespace RoguelikeCards.RCEventArgs
{
    public class DamageAppliedEventArgs : EventArgs
    {
        public DamageAppliedEventArgs(int damage, Card card)
        {
            Damage = damage;
            Card = card;
        }

        public Card Card { get; }
        public int Damage { get; }
    }
}