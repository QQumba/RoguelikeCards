using System;

namespace DefaultNamespace.Factories
{
    public class WeaponFactory : CardFactory
    {
        public GameState GameState;
        public Weapon[] Weapons;
        public int MaxWeapons;

        private GenericCardFactory<Weapon> _factory;
        public void Awake()
        {
            _factory = new GenericCardFactory<Weapon>(GameState, Weapons, MaxWeapons);
        }

        public override Card GetCard()
        {
            return _factory.GetCard();
        }
    }
}