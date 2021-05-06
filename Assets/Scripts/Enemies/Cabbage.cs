using System.Collections;

namespace DefaultNamespace.Enemies
{
    public class Cabbage : Enemy
    {
        private int _health = 15;

        void Die()
        {
            Hero.Health += 5;
        }
        
        public Cabbage(Hero hero, int health) : base(hero, health)
        {
            
        }
        
        
    }
}