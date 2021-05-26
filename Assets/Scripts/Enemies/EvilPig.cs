namespace DefaultNamespace.Enemies
{
    public class EvilPig :Enemy
    {
      
        public override void Die()
        {
            Game.Hero.ApplyDamage(-4);
            base.Die();
        }

    }
}