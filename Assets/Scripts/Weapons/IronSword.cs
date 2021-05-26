namespace DefaultNamespace
{
    public class IronSword : Weapon
    {
        protected override void PickUp()
        {
            var weapon = Instantiate(this);
            Game.Hero.GiveWeapon(weapon);
            weapon.gameObject.SetActive(false);
        }
    }
}