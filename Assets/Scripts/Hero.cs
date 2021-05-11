using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Hero : Card
    {
        [SerializeField] private int _maxHealth = 10;
        [SerializeField] private int _health;
        [SerializeField] private TextMeshPro _healthUI;
        [SerializeField] private TextMeshPro _attackUI;


        public bool IsMoving { get; private set; }
        
        public int Health => _health;

        public Weapon Weapon { get; set; }
        
        private void Start()
        {
            _health = _maxHealth;
            //Weapon = null;
        }

        private void Update()
        {
            _healthUI.text = $"{_health}/{_maxHealth}";
            _attackUI.text = Weapon == null ? "0" : Weapon.Damage.ToString();
        }

        public void GiveWeapon(Weapon weapon)
        {
            if (Weapon == null)
            {
                Weapon = weapon;
                return;
            }
            if (Weapon.Name.Equals(weapon.Name))
            {
                Weapon.Damage += weapon.Damage;
                return;
            }

            Weapon = weapon;
        }
        
        public int ApplyDamage(int damage)
        {
            var healthBeforeDamage = _health;
            _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
            if (_health <= 0)
            {
                Game.Stop();
            }

            return healthBeforeDamage - _health;
        }

        public void IncreaseMaxHealth(int value)
        {
            if (_maxHealth + value <= 0)
            {
                _maxHealth = 1;
            }
            _maxHealth += value;
        }
        
        public override bool TryEnter(Hero hero)
        {
            return false;
        }

        public override void Move(Vector2 from, Vector2 to)
        {
            IsMoving = true;
            StartCoroutine(MoveTo(from, to));
        }

        protected override IEnumerator MoveTo(Vector2 from, Vector2 to)
        {
            var fromV3 = new Vector3(from.x, from.y, 0);
            var toV3 = new Vector3(to.x, to.y, 0);
            for (float i = 0; i < 1; i+=Time.deltaTime * 4)
            {
                transform.position = Vector3.Lerp(fromV3, toV3, i);
                yield return null;
            }

            IsMoving = false;
        }
    }
}