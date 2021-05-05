namespace DefaultNamespace.Powerups
{
    public abstract class Powerup : Card
    {
        public override bool TryEnter(Hero hero)
        {
            PickUp();
            return true;
        }

        protected abstract void PickUp();
    }
}