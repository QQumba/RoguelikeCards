using System.Collections.Generic;
using DefaultNamespace.Enemies;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DefaultNamespace
{
    public abstract class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; set; }
        
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void Attack(Card enemy)
        {
            var card = enemy;
            (enemy as Enemy)?.ApplyDamage(Damage);
        }
    }
}