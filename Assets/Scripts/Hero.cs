using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Hero : Card
    {
        public int MaxHealth = 10;
        public int Health;
        public Weapon Weapon { get; private set; }

        private void Start()
        {
            Health = MaxHealth;
        }

        public void GiveWeapon(Weapon weapon)
        {
            if (Weapon.Name.Equals(weapon.Name))
            {
                Weapon.Damage += weapon.Damage;
            }

            Weapon = weapon;
        }
        
        public int ApplyDamage(int damage)
        {
            Debug.Log($"hero health before damage: {Health}");
            Debug.Log($"applying [{damage}] damage to hero");

            var healthBeforeDamage = Health;
            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
            Debug.Log($"hero health after damage: {Health}");
            if (Health <= 0)
            {
                Game.Stop();
            }

            return healthBeforeDamage - Health;
        }

        public void IncreaseMaxHealth(int value)
        {
            if (MaxHealth + value <= 0)
            {
                MaxHealth = 1;
            }
            MaxHealth += value;
        }
        
        public override bool TryEnter(Hero hero)
        {
            return false;
        }
    }
}