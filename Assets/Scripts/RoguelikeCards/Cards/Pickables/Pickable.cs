using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEditor.Compilation;

namespace RoguelikeCards.Cards.Pickables
{
    public abstract class Pickable : CardComponent, IPickable
    {
        public event Action<CardEventArgs> PickedUp;

        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void PickUp()
        {
            OnPickedUp();
            PickedUp?.Invoke(Card);
            // maybe card should not directly call Card.Accept
            Card.Accept();
        }

        protected abstract void OnPickedUp();
    }
}