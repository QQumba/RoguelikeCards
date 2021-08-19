using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards.Cards.Damageables
{
    public abstract class Damageable : CardComponent, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        public int Health { get; protected set; }

        public int MaxHealth { get; protected set; }

        public DamageAppliedEvent damageAppliedEvent;
        public HealingAppliedEvent healingAppliedEvent;
        public HealthChangedEvent healthChangedEvent;

        public event Action<DamageAppliedEventArgs> DamageApplied;
        public event Action<HealingAppliedEventArgs> HealingApplied;

        private void Start()
        {
            DamageApplied += e =>
            {
                damageAppliedEvent.Invoke(e.Damage, Card);
                healthChangedEvent.Invoke(health, maxHealth);
            };

            HealingApplied += e =>
            {
                healingAppliedEvent.Invoke(e.Heal);
                healthChangedEvent.Invoke(health, maxHealth);
            };
            healthChangedEvent.Invoke(health, maxHealth);
        }
        
        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void ApplyDamage(int damage)
        {
            OnDamageApplied(damage);
            DamageApplied?.Invoke(new DamageAppliedEventArgs(damage, Card));
        }

        public void ApplyHealing(int heal)
        {
            OnHealingApplied(heal);
            HealingApplied?.Invoke(new HealingAppliedEventArgs(heal));
        }

        protected abstract void OnDamageApplied(int damage);
        protected abstract void OnHealingApplied(int heal);
    }
}