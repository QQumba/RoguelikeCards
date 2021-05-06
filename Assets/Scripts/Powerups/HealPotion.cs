using UnityEngine;

namespace DefaultNamespace.Powerups
{
    public class HealPotion : Powerup
    {
        public int HealingPower = 3;

        protected override void PickUp()
        {
            Debug.Log($"picked up potion");
            Game.Hero.ApplyDamage(-HealingPower);
        }
    }
}