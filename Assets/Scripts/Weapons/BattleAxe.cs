using System;
using System.Runtime.InteropServices.ComTypes;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using UnityEngine;

namespace DefaultNamespace
{
    public class BattleAxe : Weapon
    {
        private void Start()
        {
            Name = "Battle Axe";
            Damage = 12;
        }

        public override void Attack(Enemy enemy)
        {

            if(enemy.Top is Enemy enemyTopCard)
                base.Attack(enemyTopCard);
            
            if(enemy.Bottom is Enemy enemyBottomCard)
                base.Attack(enemyBottomCard);
            base.Attack(enemy);
          
    

        }

        protected override void PickUp()
        {
            var weapon = Instantiate(this);
            Game.Hero.GiveWeapon(weapon);
            weapon.gameObject.SetActive(false);
        }
    }
}