﻿using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public abstract class Enemy : Card
    {
        [SerializeField] private TextMeshPro _healthText;
        
        public int MaxHealth;
        public int Health;
        public string Name;
        public string Description;

        private void Update()
        {
            _healthText.text = $"{Health}/{MaxHealth}";
        }

        public override bool TryEnter(Hero hero)
        {
            if (hero.Weapon is null)
            {
                var damageApplied = ApplyDamage(hero.Health);
                hero.ApplyDamage(damageApplied);
                return true;
                Game.TurneCount++;
            }
            hero.Weapon.Attack(this);
            return false;
        }

        public virtual int ApplyDamage(int damage)
        {
            var healthBeforeDamage = Health;
            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
            if (Health <= 0)
            {
                Die();
            }
            return healthBeforeDamage - Health;
        }

        public virtual void Die()
        {
            //Game.SpawnCoin(this);
        }
    }
}