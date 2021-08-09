using RoguelikeCards.Cards;

namespace RoguelikeCards
{
    public abstract class HandWeapon
    {
        public abstract void Attack(IDamageable damageable);
    }
}