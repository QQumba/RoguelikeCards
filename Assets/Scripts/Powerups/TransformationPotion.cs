using System.Security.Cryptography;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace.Powerups
{
    public class TransformationPotion : Powerup
    {
        public Enemy Enemy;
        
        protected override void PickUp()
        {
            for (int i = 0; i < Game.Cards.Length; i++)
            {
                if (Game.Cards[i] is Powerup && Game.Cards[i] != this)
                {
                    var position = Game.Cards[i].transform.position;
                    Game.Cards[i].Delete();
                    Game.Cards[i] = Instantiate(Enemy, Vector3.zero, Quaternion.identity);
                    Game.Cards[i].AssignToGame(Game);
                }
            }
        }
    }
}