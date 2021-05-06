using DefaultNamespace.Enemies;
using DefaultNamespace.Powerups;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Factories
{
    public class PowerupFactory : ICardFactory
    {
        private readonly Game _game;
        private readonly Powerup[] _powerups;

        public int SpawnChanceThreshold { get; }

        public PowerupFactory(Game game, Powerup[] powerups, int spawnChanceThreshold)
        {
            _game = game;
            _powerups = powerups;
            SpawnChanceThreshold = spawnChanceThreshold;
        }

        public Card GetCard()
        {
            //todo return card
            return null;
        }
    }
}