using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards
{
    [CreateAssetMenu(fileName = "Sword", menuName = "Weapon/Sword")]
    public class Sword : HandWeapon
    {
        [SerializeField] private int damage;
        public override int Damage
        {
            get => damage;
            protected set => damage = value;
        }

        public override HandWeapon GetInstance()
        {
            return Instantiate(this);
        }

        public override void Attack(IDamageable damageable)
        {
            var health = damageable.Health;
            damageable.ApplyDamage(damage);
            
            damage -= health;
            
            if (damage < 0)
            {
                damage = 0;
            }
        }
    }
}