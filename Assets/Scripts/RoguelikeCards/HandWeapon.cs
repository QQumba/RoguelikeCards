using System;
using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards
{
    public abstract class HandWeapon : ScriptableObject
    {
        public abstract int Damage { get; }
        public abstract void Attack(IDamageable damageable);
    }
}