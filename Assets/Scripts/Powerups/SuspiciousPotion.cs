namespace DefaultNamespace.Powerups
{
    public class SuspiciousPotion : Powerup
    {
        protected override void PickUp()
        {
            Game.Hero.ApplyDamage(Game.Hero.Health - 1);
        }
    }
}