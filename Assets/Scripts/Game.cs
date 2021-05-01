using System.Collections.Generic;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using DefaultNamespace.Powerups;
using NUnit.Framework;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game
    {
        public readonly Dictionary<Vector2, Card> _field;
        private Hero _hero;
        private readonly ICardFactory _factory;
        
        public int TurnCount { get; set; }
        
        public int EnemyCount { get; set; }
        public int EnemyHealth { get; set; }
        
        public int PowerupCount { get; set; }
        public int ChestCount { get; set; }

        private int _size;
        public Game(int size, Hero hero, ICardFactory factory)
        {
            _field = new Dictionary<Vector2, Card>();
            _size = size;
            _hero = hero;
            _factory = factory;
        }

        public void Start()
        {
            FillField(_size, _size);
        }

        public Hero Hero => _hero;

        private void FillField(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var vector = new Vector2(i, j);
                    Debug.Log($"car location: {vector.x}.{vector.y}");
                    _field.Add(vector, _factory.GetCard());
                    if (_field[vector] != null)
                    {
                        Debug.Log($"card: {_field[vector]}, coord: {vector.x}.{vector.y}");
                    }
                }
            }
        }
    }
}