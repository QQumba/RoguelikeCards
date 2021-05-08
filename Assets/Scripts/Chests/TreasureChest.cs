using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace.Chests
{
    public class TreasureChest : Chest
    {
        public Powerup[] Powerups;
            
        public override void Open()
        {
            Game.ReplaceCard(Powerups[Random.Range(0, Powerups.Length)], this);
        }
    }
}