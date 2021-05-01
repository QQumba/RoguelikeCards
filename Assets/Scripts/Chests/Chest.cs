﻿using System;

namespace DefaultNamespace.Chests
{
    public abstract class Chest : Card
    {
        protected Chest(Hero hero, int health) : base(hero)
        {
            
        }

        public override bool TryEnter()
        {
            OnOpen();
            return false;
        }
        protected abstract void OnOpen();
        {
            
        }
    }
}