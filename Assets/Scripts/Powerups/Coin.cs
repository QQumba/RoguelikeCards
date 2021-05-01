using UnityEngine;

namespace DefaultNamespace.Powerups
{
    public class Coin : Powerup
    {
        public Coin(Hero hero) : base(hero)
        {
        }

        protected override void PickUp()
        {
            Debug.Log("mm coins");
        }
    }
}