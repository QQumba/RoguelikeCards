using RoguelikeCards.Cards;

namespace RoguelikeCards.Heroes
{
    public interface ICardComponentVisitor
    {
        void Visit(IPickable pickable);
        void Visit(IEnemy enemy);
        void Visit(IDamageable damageable);
    }
}