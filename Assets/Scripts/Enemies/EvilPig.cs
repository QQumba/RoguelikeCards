namespace DefaultNamespace.Enemies
{
    public class EvilPig :Enemy
    {
        private void Start()
        {
            Name = "Evil Pig";
            MaxHealth = 8;
            Health = MaxHealth;
        }
        public int Die(int damage)
        {
            
            base.Die();
            return base.ApplyDamage(damage) + 4;
        }
        
        
    }
}