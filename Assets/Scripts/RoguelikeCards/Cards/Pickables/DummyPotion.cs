using System;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Powerups
{
    public class DummyPotion : Card, IPickable
    {
        public event Action<CardEventArgs> PickedUp;

        public void PickUp()
        {
            Debug.Log("pick up a potion");
            PickedUp?.Invoke(this);
        }
    }
}