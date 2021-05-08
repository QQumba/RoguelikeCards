using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class EnemyFactory : CardFactory
    {
        public Enemy[] Enemies;
        

        public override Card GetCard()
        {
            return Enemies[Random.Range(0, Enemies.Length)];
        }
    }
}