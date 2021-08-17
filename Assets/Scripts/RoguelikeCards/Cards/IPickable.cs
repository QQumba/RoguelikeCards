using System;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.Cards
{
    public interface IPickable
    {
        event Action<CardEventArgs> PickedUp;
        void PickUp();
    }
}