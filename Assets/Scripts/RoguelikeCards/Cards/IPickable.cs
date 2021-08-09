using System;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.Cards
{
    public interface IPickable
    {
        event EventHandler<CardEventArgs> PickedUp;
        void PickUp();
    }
}