using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace.Chests
{
    public class TreasureChest : Chest
    {
        public Card[] Cards;
            
        public override void Open()
        {
            Game.ReplaceCard(Cards[Random.Range(0, Cards.Length)], this);
        }
    }
}