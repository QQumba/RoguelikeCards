using System;
using DefaultNamespace.Enemies;
using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class EnemyFactory : ICardFactory
    {
        public Card GetCard()
        {
            throw new Exception();
        }
    }
}