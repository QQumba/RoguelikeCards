using System.Collections.Generic;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using UnityEngine;

namespace DefaultNamespace
{
    public class IronAxe : Weapon
    {
        protected override void PickUp()
        {
            var weapon = Instantiate(this);
            Game.Hero.GiveWeapon(weapon);
            weapon.gameObject.SetActive(false);
        }
        public override void Attack(Enemy enemy)
        {
            var chance = Random.Range(0, 4);
            switch (chance)
            {
                case 1 : 
                    (enemy.Top as Enemy)?.ApplyDamage(Damage);
                    break; 
                case 2 :
                    (enemy.Bottom as Enemy)?.ApplyDamage(Damage); 
                    break; 
                case 3 :
                    (enemy.Left as Enemy)?.ApplyDamage(Damage);    
                    break; 
                case 0 :
                    (enemy.Right as Enemy)?.ApplyDamage(Damage);    
                    break;
            }
            
            base.Attack(enemy);
            
        }
    }
}