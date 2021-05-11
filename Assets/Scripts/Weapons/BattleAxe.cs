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

            if (enemy.Top is Enemy enemyTopCard)
                enemyTopCard.ApplyDamage(Damage);

            if (enemy.Bottom is Enemy enemyBottomCard)
                enemyBottomCard.ApplyDamage(Damage);
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