using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Hero
    {
        private int _health;
        private int _maxHealth;
        public Weapon Weapon;

        public Hero(int maxHealth)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;
        }


        public int Health
        {
            get { return _health;}
            set
            {
                _health = Mathf.Clamp(value, 0, _maxHealth);
            }
                
        }
        
        
        
    }
}