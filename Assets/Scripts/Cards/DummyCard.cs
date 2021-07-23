using System;
using System.Collections;
using DefaultNamespace.Cards.Heroes;
using DefaultNamespace.CardStates;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Cards
{
    public class DummyCard : Card, IEnemy
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

        public void ApplyDamage(uint damage)
        {
            health = Mathf.Clamp((int) (health - damage), 0, maxHealth);
            State = new StateDamaged(this);
            healthChanged.Invoke(health, maxHealth);
            if (health <= 0)
            {
                Die();
                return;
            }
            damageApplied.Invoke((int) damage);
        }

        public void Heal(uint value)
        {
            health = Mathf.Clamp((int) (health + value), 0, maxHealth);
            healingApplied.Invoke((int) value);
            healthChanged.Invoke(health, maxHealth);
        }

        public event Action<int> Died;

        public void Die()
        {
            if (Entered)
            {
                State = new StateEntered(this, Game);
                return;
            }

            State = new StateDestroyed(this, Game);
        }

        public override void TurnUpdate()
        {
            // var chance = Random.Range(0f, 1f);
            // if (chance < 0.05)
            // {
            //     ApplyDamage(10);
            // }
        }

        public override void Accept(ICardVisitor visitor)
        {
            // Entered = true;
            visitor.Visit(this as IEnemy);
        }
    }

    [Serializable]
    public class HealthChangedEvent : UnityEvent<int, int>
    {
    }

    [Serializable]
    public class DamageAppliedEvent : UnityEvent<int>
    {
    }

    [Serializable]
    public class HealingAppliedEvent : UnityEvent<int>
    {
    }
}