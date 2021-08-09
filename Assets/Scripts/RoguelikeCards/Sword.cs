using RoguelikeCards.Cards;

namespace RoguelikeCards
{
    public class Sword : HandWeapon
    {
        public override void Attack(IDamageable damageable)
        {
            damageable.ApplyDamage(5);
        }
    }
}