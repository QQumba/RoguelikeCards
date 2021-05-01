using System;
using DefaultNamespace.Factories;
using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInitializer : MonoBehaviour
    {
        public Game Game;

        private void Start()
        {
            var factory = new CardFactory();
            var hero = new Hero()
            {
                Health = 3
            };
            Game = new Game(3, hero, factory);
            factory.AddFactory(new PowerupFactory(Game, new Powerup[]{new HealPotion(hero)}, 30));
            
            Game.Start();
        }
    }
}