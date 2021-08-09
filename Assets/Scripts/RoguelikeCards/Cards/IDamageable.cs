using System;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.Cards
{
    public interface IDamageable
    {
        int Health { get; }
        int MaxHealth { get; }
        event Action<DamageAppliedEventArgs> DamageApplied;
        event Action<HealingAppliedEventArgs> HealingApplied;
        void ApplyDamage(int damage);
        void ApplyHealing(int heal);
    }
}