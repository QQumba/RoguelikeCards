using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards.Cards.Damageables
{
    public class CommonDamageable : Damageable
    {
        protected override void OnDamageApplied(int damage)
        {
            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
        }

        protected override void OnHealingApplied(int heal)
        {
            Health = Mathf.Clamp(Health + heal, 0, MaxHealth);
        }
    }
}