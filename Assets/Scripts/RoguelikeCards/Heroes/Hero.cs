using System;
using RoguelikeCards.Cards;
using RoguelikeCards.RCEventArgs;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards.Heroes
{
    public class Hero : CardComponent, IDamageable, ICardComponentVisitor
    {
        [SerializeField] private HandWeapon startWeapon;
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        private HandWeapon _weapon;

        public int Health => health;
        public int MaxHealth => maxHealth;
        public DamageAppliedEvent damageAppliedEvent;
        public HealingAppliedEvent healingAppliedEvent;
        public HealthChangedEvent healthChangedEvent;
        [SerializeField] private StringValueChangedEvent weaponAttackChangedEvent;
        public event Action<DamageAppliedEventArgs> DamageApplied;
        public event Action<HealingAppliedEventArgs> HealingApplied;

        private void Awake()
        {
            GiveWeapon(startWeapon);
        }

        private void Start()
        {
            DamageApplied += e =>
            {
                healthChangedEvent.Invoke(health, maxHealth);
            };
            
            HealingApplied += e =>
            {
                healthChangedEvent.Invoke(health, maxHealth);
            };
            
            healthChangedEvent.Invoke(health, maxHealth);
            weaponAttackChangedEvent.Invoke(_weapon.Damage.ToString());
        }
        public void GiveWeapon(HandWeapon weapon)
        {
            _weapon = weapon;
        }

        public void ApplyDamage(int damage)
        {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            DamageApplied?.Invoke(new DamageAppliedEventArgs(damage, Card));
            if (health == 0)
            {
                //TODO add end of the game
                Debug.Log("GAME OVER!");
            }
        }

        public void ApplyHealing(int heal)
        {
            health = Mathf.Clamp((health + heal), 0, maxHealth);
            HealingApplied?.Invoke(new HealingAppliedEventArgs(heal));
        }

        public void Visit(IPickable pickable)
        {
            pickable.PickUp();
        }

        public void Visit(IEnemy enemy)
        { 
            _weapon.Attack(enemy.Damageable);
            weaponAttackChangedEvent.Invoke(_weapon.Damage.ToString());
        }

        /// <summary>
        /// Don't interact directly with IDamageable components.
        /// </summary>
        /// <param name="damageable"></param>
        public void Visit(IDamageable damageable)
        {
        }

        public override void Accept(ICardComponentVisitor visitor)
        {
        }
    }
}