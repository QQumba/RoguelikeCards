using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public abstract class Enemy : Card
    {

        public int MaxHealth;
        public int Health;
        public string Name;
        public string Description;

        public override bool TryEnter(Hero hero)
        {
            if (hero.Weapon is null)
            {
                if (hero.Health <= 1)
                {
                    hero.ApplyDamage(hero.Health);
                }   
                var damageApplied = ApplyDamage(hero.Health);
                hero.ApplyDamage(damageApplied);
                return true;
            }

            hero.Weapon.Attack(this);
            // TODO ATTACK
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

            Debug.Log($"{Name} died.");
        }
    }
}