using System;
using DefaultNamespace.Enemies;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class Hand : Weapon
    {
        private static Hand _hand;

        public static Hand GetInstance()
        {
            return _hand;
        }

        private void Update()
        {
            Damage = Game.Hero.Health;
        }

        private void Awake()
        {
            _hand = this;
            Damage = Game.Hero.Health;
        }

        protected override void PickUp()
        {
            
        }

        public override void Attack(Enemy enemy)
        {
            if (Damage > enemy.Health)
            {
                Game.Hero.ApplyDamage(enemy.Health);
                Game.MoveHero(enemy);
                return;
            }
            Game.Stop();
        }
    }

    
}

