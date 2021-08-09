using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using RoguelikeCards.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

namespace RoguelikeCards.Cards
{
    public class DummyCard : Card, IEnemy, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        [SerializeField] private HealthChangedEvent healthChanged;
        [SerializeField] private DamageAppliedEvent damageApplied;
        [SerializeField] private HealingAppliedEvent healingApplied;

        [SerializeField] private Sprite backgroundHighlighted;
        [SerializeField] private Sprite backgroundDefault;

        private SpriteRenderer _background;
        
        public int Health => health;
        public int MaxHealth => maxHealth;
        public event Action<DamageAppliedEventArgs> DamageApplied;
        public event Action<HealingAppliedEventArgs> HealingApplied;
        public IDamageable Damageable => this;
        public event Action<CardEventArgs> Died;

        private void Start()
        {
            _background = GetComponent<SpriteRenderer>();
            healthChanged.Invoke(health, maxHealth);
        }

        private void OnMouseEnter()
        {
            _background.sprite = backgroundHighlighted;
        }

        private void OnMouseExit()
        {
            _background.sprite = backgroundDefault;
        }

        private void Awake()
        {
            if (health == 0)
            {
                health = MaxHealth;
            }
        }

        public void ApplyDamage(int damage)
        {
            health = Mathf.Clamp( health - damage, 0, maxHealth);
            healthChanged.Invoke(health, maxHealth);
            DamageApplied?.Invoke(new DamageAppliedEventArgs((int)damage,this));
            if (health <= 0)
            {
                Die();
                return;
            }
            damageApplied.Invoke((int) damage);
        }

        public void ApplyHealing(int heal)
        {
            health = Mathf.Clamp(health + heal, 0, maxHealth);
            healingApplied.Invoke((int) heal);
            HealingApplied?.Invoke( new HealingAppliedEventArgs(heal));
            healthChanged.Invoke(health, maxHealth);
        }
        
        public void Die()
        {
            Died?.Invoke(this);
            Destroy();
        }

        public override void TurnUpdate()
        {
        }

        protected override void AcceptHero(ICardComponentVisitor cardComponentVisitor)
        {
            cardComponentVisitor.Visit(this as IEnemy);
        }
    }

    /// <summary>
    /// takes current health and max health as 1st and 2nd parameters
    /// </summary>

    [Serializable]
    public class HealingAppliedEvent : UnityEvent<int>
    {
    }
}