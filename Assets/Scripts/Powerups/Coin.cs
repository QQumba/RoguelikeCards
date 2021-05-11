namespace DefaultNamespace.Powerups
{
    public class Coin : Powerup
    {
        protected override void PickUp()
        {
            Game.CoinCount++;
        }
    }
}