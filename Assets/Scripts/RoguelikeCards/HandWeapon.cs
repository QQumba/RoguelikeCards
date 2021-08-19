using System;
using RoguelikeCards.Cards;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards
{
    public abstract class HandWeapon : ScriptableObject
    {
        public event Action<int> DamageChanged;
        public abstract int Damage { get; protected set; }

        public void AddDamage(int value)
        {
            Damage += value;
            DamageChanged?.Invoke(Damage);
        }
        public abstract HandWeapon GetInstance();
        public abstract void Attack(IDamageable damageable);
    }
}