namespace DefaultNamespace.Powerups
{
    public abstract class Powerup : Card
    {
        protected Powerup(Hero hero) : base(hero)
        {
        }

        public override bool TryEnter()
        {
            PickUp();
            return true;
        }

        protected abstract void PickUp();
    }
}