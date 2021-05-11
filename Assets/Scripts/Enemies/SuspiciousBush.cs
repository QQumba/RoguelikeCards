﻿using System;

namespace DefaultNamespace.Enemies
{
    public class SuspiciousBush : Enemy
    {
        private void Start()
        {
            Name = "Suspicious bush";
            MaxHealth = 6;
            Health = MaxHealth;
        }

        public override int ApplyDamage(int damage)
        {
            return base.ApplyDamage(damage);
        }

        public override void Die()
        {
            Game.SpawnCoin(this);
            base.Die();
        }
    }
}