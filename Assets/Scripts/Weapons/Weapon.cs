using System.Collections.Generic;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Weapon : Card
    {
        public string Name;
        public int Damage;
        
        
        public override bool TryEnter(Hero hero)
        {
            PickUp();
            return true;
        }

        protected abstract void PickUp();
        
        

        public virtual void Attack(Enemy enemy)
        {
            Debug.Log("Enemy attached");
            enemy.ApplyDamage(Damage);
            Damage -= enemy.Health;
            Debug.Log("Damage chenged");
            if (Damage < 0)
                Game.Hero.Weapon = null;
                
            if (enemy.Health > 0)
               Game.Hero.Weapon = null;
            
          
            
        }
    }
}
        
