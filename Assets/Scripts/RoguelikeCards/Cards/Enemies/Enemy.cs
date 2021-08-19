using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Enemies
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class Enemy : CardComponent, IEnemy
    {
        private IDamageable _damageable;

        public IDamageable Damageable => _damageable ??= GetComponent<IDamageable>();

        public event Action<CardEventArgs> Died;

        private void Start()
        {
            Damageable.DamageApplied += e =>
            {
                if (_damageable.Health <= 0)
                {
                    Die();
                }
            };
        }

        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public void Die()
        {
            OnDied();
            Died?.Invoke(Card);
        }

        protected abstract void OnDied();
    }
}