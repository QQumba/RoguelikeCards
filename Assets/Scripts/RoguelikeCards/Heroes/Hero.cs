using System;
using RoguelikeCards.Cards;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Heroes
{
    public class Hero : Card, IDamageable, ICardComponentVisitor
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        private HandWeapon _weapon;

        public int Health => health;
        public int MaxHealth => maxHealth;
        public event Action<DamageAppliedEventArgs> DamageApplied;
        public event Action<HealingAppliedEventArgs> HealingApplied;

        private void Awake()
        {
            GiveWeapon(new Sword());
        }

        public void GiveWeapon(HandWeapon handWeapon)
        {
            _weapon = handWeapon;
        }

        public void ApplyDamage(int damage)
        {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            if (health == 0)
            {
                //TODO add end of the game
                Debug.Log("GAME OVER!");
            }
        }

        public void ApplyHealing(int heal)
        {
            health = Mathf.Clamp((health + heal), 0, maxHealth);
        }

        public void Visit(IPickable pickable)
        {
            pickable.PickUp();
        }

        public void Visit(IEnemy enemy)
        {
            _weapon.Attack(enemy.Damageable);
        }

        public void Visit(IDamageable damageable)
        {
            throw new NotImplementedException();
        }

        protected override void AcceptHero(ICardComponentVisitor cardComponentVisitor)
        {
        }
    }
}