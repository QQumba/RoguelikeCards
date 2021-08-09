using System;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.Cards
{
    public interface IEnemy
    {
        IDamageable Damageable { get; }
        event Action<CardEventArgs> Died; 
        void Die();
    }
}