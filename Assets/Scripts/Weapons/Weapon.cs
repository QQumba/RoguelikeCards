using System;
using System.Collections.Generic;
using DefaultNamespace.Enemies;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Weapon : Card
    {
        [SerializeField] private TextMeshPro _attackText;
        
        public string Name;

        public int Damage;

        private int minDamage = 0;

        private void Update()
        {
                _attackText.text = Damage.ToString();
        }


        public override bool TryEnter(Hero hero)
        {
            PickUp();
            Game.TurnCount++;
            return true;
        }

        protected abstract void PickUp();
        
        

        public virtual void Attack(Enemy enemy)
        {
            
            var damageBeforeAttack = Damage;
            
            Damage -= enemy.Health;
            enemy.ApplyDamage(damageBeforeAttack);
            if (Damage < minDamage)
                Damage = minDamage;
            if (Damage == minDamage )
            {
                Game.Hero.Weapon = Hand.GetInstance();
            }
           

        }
    }
}