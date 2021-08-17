using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards
{
    [CreateAssetMenu(fileName = "Sword", menuName = "Weapon/Sword")]
    public class Sword : HandWeapon
    {
        [SerializeField] private int damage;
        public override int Damage => damage;

        public override void Attack(IDamageable damageable)
        {
            damageable.ApplyDamage(damage);
        }
    }
}