namespace DefaultNamespace.Cards
{
    public class Sword : HandWeapon
    {
        public override void Attack(IEnemy enemy)
        {
            enemy.ApplyDamage(5);
        }
    }
}