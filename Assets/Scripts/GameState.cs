using System;
using System.Collections.Generic;
using DefaultNamespace.Chests;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
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
        
        public List<Chest> Chests
        {
            get
            {
                var chests = new List<Chest>();
                foreach (var card in Cards)
                {
                    if (card is Chest chest)
                    {
                        chests.Add(chest);
                    }
                }

                return chests;
            }
        }

        public List<TCard> GetCards<TCard>() where TCard : Card
        {
            var cards = new List<TCard>();
            foreach (var card in Cards)
            {
                if (card is TCard tCard)
                {
                    cards.Add(tCard);
                }
            }

            return cards;
        }
        
        private void Start()
        {
            Cards = new Card[SideSize * SideSize];
        }
    }
}