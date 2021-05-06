using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace.Powerups
{
    public class TransformationPotion : Powerup 
    {
        protected override void PickUp()
        {
            for (int i = 0; i < Game.Cards.Length; i++)
            {
                if (Game.Cards[i] is Powerup && Game.Cards[i] != this)
                {
                    var position = Game.Cards[i].transform.position;
                    Game.Cards[i].Delete();
                    Game.Cards[i] = Instantiate(Game.AllEnemies[0], position, Quaternion.identity);
                    Game.Cards[i].Game = Game;
                }
            }
        }
    }
}