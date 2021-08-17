using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards.Cards.Damageables
{
    public class CommonDamageable : CardComponent, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        public int Health => health;

        public int MaxHealth => maxHealth;

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

        public void ApplyDamage(int damage)
        {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            DamageApplied?.Invoke(new DamageAppliedEventArgs(damage, Card));
        }

        public void ApplyHealing(int heal)
        {
            health = Mathf.Clamp(health + heal, 0, maxHealth);
            HealingApplied?.Invoke(new HealingAppliedEventArgs(heal));
        }

        public override void Accept(ICardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}