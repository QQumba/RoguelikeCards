using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Enemies
{
    [RequireComponent(typeof(IDamageable))]
    public class CommonEnemy : CardComponent, IEnemy
    {
        private IDamageable _damageable;

        public IDamageable Damageable => _damageable ??= GetComponent<IDamageable>();
        
        public event Action<CardEventArgs> Died;

        public void Die()
        {
            Died?.Invoke(Card);
        }

        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}