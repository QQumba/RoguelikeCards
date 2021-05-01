namespace DefaultNamespace.Powerups
{
    public class HealPotion : Powerup
    {
        public HealPotion(Hero hero) : base(hero)
        {
        }

        protected override void PickUp()
        {
            Hero.Health += 3;
        }
    }
}