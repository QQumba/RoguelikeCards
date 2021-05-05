using System;

namespace DefaultNamespace.Enemies
{
    public class SuspiciousBush : Enemy
    {
        private void Start()
        {
            Name = "Suspicious bush";
            MaxHealth = 4;
            Health = MaxHealth;
        }

        public override int ApplyDamage(int damage)
        {
            return base.ApplyDamage(damage) / 2;
        }

        public override void Die()
        {
            base.Die();
        }
    }
}