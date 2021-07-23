using System;
using System.ComponentModel;
using DefaultNamespace.Cards;
using DefaultNamespace.Cards.Heroes;

namespace Heroes
{
    public class DefaultCardVisitor : ICardVisitor
    {
        private readonly Hero _hero;

        public DefaultCardVisitor(Hero hero)
        {
            _hero = hero;
        }

        public void Visit(Card card)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(IEnemy enemy)
        {
            enemy.ApplyDamage(1);
        }

        public void Visit(IPickable pickable)
        {
            pickable.PickUp();
        }

        public void Visit(IDamageable damageable)
        {
            throw new NotImplementedException();
        }
    }
}