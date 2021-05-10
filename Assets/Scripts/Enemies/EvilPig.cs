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
        
        public override void Die()
        {
            Game.Hero.ApplyDamage(-4);
            base.Die();
        }

    }
}