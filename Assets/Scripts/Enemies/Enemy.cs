using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public abstract class Enemy : Card
    {
        protected int _health;
        protected string _name;
        protected string _description;
        
        
        protected Enemy(Hero hero, int health) : base(hero)
        {
            _health = health;
        }

        public override bool TryEnter()
        {
            if (Hero.Weapon is null)
            {
                Hero.Health -= _health;
                ApplyDamage(Hero.Health);
                return true;
            }

            var damageConsumed = _health;
            ApplyDamage(Hero.Weapon.Damage);
            Hero.Weapon.Damage -= damageConsumed;
            return false;
        }

        void ApplyDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
                
            }
        }

        void Die()
        {
            
            Debug.Log("lol i died");
            
        }
    }
}