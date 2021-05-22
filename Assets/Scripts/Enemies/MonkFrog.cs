namespace DefaultNamespace.Enemies
{
    public class MonkFrog : Enemy
    {
      
        

        public override void Die()
        {
            Game.Hero.Weapon = null;
            base.Die();
        }
        
        
    }
}