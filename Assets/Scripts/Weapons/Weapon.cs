using System.Collections.Generic;
using DefaultNamespace.Enemies;

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
        
        public void Attack(Card enemy)
        {
            var card = enemy;
            (enemy as Enemy)?.ApplyDamage(Damage);
        }
    }
}
        
