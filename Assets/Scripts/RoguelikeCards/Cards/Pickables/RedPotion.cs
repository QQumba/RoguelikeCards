using System;
using System.Linq;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Pickables
{
    public class RedPotion : CardComponent, IPickable
    {
        [SerializeField] private int healPower;

        public event Action<CardEventArgs> PickedUp;

        public void PickUp()
        {
            var hero = Card.Navigator.Hero;
            hero.ApplyHealing(healPower);
            PickedUp?.Invoke(Card);
            Card.Accept();
        }

        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}