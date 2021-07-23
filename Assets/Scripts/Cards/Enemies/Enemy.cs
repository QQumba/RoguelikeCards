using System;
using DefaultNamespace.Cards.Heroes;

namespace DefaultNamespace.Cards.Enemies
{
    public abstract class Enemy : Card, IEnemy
    {
        public override void Accept(ICardVisitor visitor)
        {
            visitor.Visit(this as IEnemy);
        }

        public int Health { get; }
        public int MaxHealth { get; }

        public abstract void ApplyDamage(uint damage);
        public void Heal(uint value)
        {
            throw new System.NotImplementedException();
        }

        public event Action<int> Died;
        public abstract void Die();
    }
}