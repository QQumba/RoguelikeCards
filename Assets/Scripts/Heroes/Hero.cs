using DefaultNamespace.Cards.Heroes;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class Hero : Card, IDamageable, ICardVisitor
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        private HandWeapon _weapon;

        public int Health => health;
        public int MaxHealth => maxHealth;

        private void Awake()
        {
            GiveWeapon(new Sword());
        }

        public void GiveWeapon(HandWeapon handWeapon)
        {
            _weapon = handWeapon;
        }

        public void ApplyDamage(uint damage)
        {
            health = Mathf.Clamp((int) (health - damage), 0, maxHealth);
            if (health == 0)
            {
                Die();
            }
        }

        public void Heal(uint value)
        {
            health = Mathf.Clamp((int) (health + value), 0, maxHealth);

        }

        public void Visit(IPickable pickable)
        {
            pickable.PickUp();
        }

        public void Visit(IEnemy enemy)
        {
            _weapon.Attack(enemy);
        }

        public void Visit(Card card)
        {
            
        }

        private void Die()
        {
            Debug.Log("GAME OVER");
        }

        public override void Accept(ICardVisitor visitor) { }
    }
}