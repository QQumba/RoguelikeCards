namespace DefaultNamespace.Powerups
{
    public abstract class Powerup : Card
    {
        public override bool TryEnter(Hero hero)
        {
            PickUp();
            Game.TurnCount++;
            return true;
        }

        protected abstract void PickUp();
    }
}