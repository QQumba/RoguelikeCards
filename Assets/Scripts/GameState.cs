using System;
using System.Collections.Generic;
using DefaultNamespace.Enemies;
using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameState : MonoBehaviour
    {
        public int SideSize = 3;
        public Card[] Cards { get; private set; }
        
        public List<Enemy> Enemies
        {
            get
            {
                var enemies = new List<Enemy>();
                foreach (var card in Cards)
                {
                    if (card is Enemy enemy)
                    {
                        enemies.Add(enemy);
                    }
                }

                return enemies;
            }
        }
        
        public List<Powerup> Powerups
        {
            get
            {
                var powerups = new List<Powerup>();
                foreach (var card in Cards)
                {
                    if (card is Powerup powerup)
                    {
                        powerups.Add(powerup);
                    }
                }

                return powerups;
            }
        }
        
        private void Start()
        {
            Cards = new Card[SideSize * SideSize];
            
            throw new NotImplementedException();
        }
    }
}