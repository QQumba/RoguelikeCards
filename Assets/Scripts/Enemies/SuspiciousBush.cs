using System;

namespace DefaultNamespace.Enemies
{
    public class SuspiciousBush : Enemy
    {
        public override void Die()
        {
            Game.SpawnCoin(this);
            base.Die();
        }
    }
}