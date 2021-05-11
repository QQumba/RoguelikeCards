namespace DefaultNamespace.Enemies
{
    public class MonkFrog : Enemy
    {
        private void Start()
        {
            Name = "Monk Frog";
            MaxHealth = 8;
            Health = MaxHealth;
        }

        

        public override void Die()
        {
            Game.Hero.Weapon = null;
            base.Die();
        }
        
        
    }
}