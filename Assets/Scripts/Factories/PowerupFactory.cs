using System;
using DefaultNamespace.Powerups;

namespace DefaultNamespace.Factories
{
    public class PowerupFactory : CardFactory
    {
        public GameState GameState;
        public Powerup[] Powerups;
        public int MaxPowerups = 4;

        private GenericCardFactory<Powerup> _factory;
        
        private void Awake()
        {
            _factory = new GenericCardFactory<Powerup>(GameState, Powerups, MaxPowerups);
        }

        public override Card GetCard()
        {
            return _factory.GetCard();
        }
    }
}