using System;

namespace DefaultNamespace.Cards
{
    public interface IEnemy : IDamageable
    {
        event Action<int> Died; 
        void Die();
    }
}