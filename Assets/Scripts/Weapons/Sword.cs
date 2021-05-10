using System;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace
{
    public class Sword : Weapon
    {
        private void Start()
        {
            Name = "Sword";
            Damage = 10;
        }
        
        protected override void PickUp()
        {
            var weapon = Instantiate(this);
            Game.Hero.GiveWeapon(weapon);
            weapon.gameObject.SetActive(false);
        }

        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);
            Damage -= enemy.Health;
        }
    }
}