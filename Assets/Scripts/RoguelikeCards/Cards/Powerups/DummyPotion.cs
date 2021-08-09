using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Powerups
{
    public class DummyPotion : Card, IPickable
    {
        protected override void AcceptHero(ICardComponentVisitor cardComponentVisitor)
        {
            cardComponentVisitor.Visit(this as IPickable);
        }

        public event EventHandler<CardEventArgs> PickedUp;

        public void PickUp()
        {
            Debug.Log("pick up a potion");
            PickedUp?.Invoke(this, this);
            Destroy();
        }
    }
}