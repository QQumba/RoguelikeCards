﻿using System.Collections.Generic;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Weapon : Card
    {
        public string Name;

        public int Damage;

        private int minDamage = 0;
        
        public override bool TryEnter(Hero hero)
        {
            PickUp();
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
                Debug.Log($"Weapon = {Game.Hero.Weapon}");
                Game.Hero.Weapon = null;
                Debug.Log($"Weapon = {Game.Hero.Weapon}");
            }
           // Debug.Log($"Enemy attached{enemy.ApplyDamage(Damage)}");
            //Debug.Log("Damage chenged");
           

        }
    }
}