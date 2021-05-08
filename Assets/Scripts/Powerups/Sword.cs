using UnityEngine;

namespace DefaultNamespace.Powerups
{
    public class Sword : Powerup
    {
        protected override void PickUp()
        {
            Debug.Log("Sword.PuckUp -> picked up a sword.");
        }
    }
}