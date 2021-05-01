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

        private readonly int _spawnChanceThreshold;

        public PowerupFactory(Game game, Powerup[] powerups, int spawnChanceThreshold)
        {
            _game = game;
            _powerups = powerups;
            _spawnChanceThreshold = spawnChanceThreshold;
        }

        public Card GetCard()
        {
            Debug.Log("PowerupFactory: generate card");
            var chance = Random.value * 100 / (_game.PowerupCount + 1);
            Debug.Log($"PowerupFactory: chance: {chance}, threshold: {_spawnChanceThreshold}, powerups count: {_game.PowerupCount}");
            if (chance > _spawnChanceThreshold)
            {
                _game.PowerupCount++;
                return _powerups[0];
                //return _powerups[(int)(Random.value * 100) % _powerups.Length];
            }
            
            return null;
        }
    }
}