using DefaultNamespace.Cards.Heroes;

namespace DefaultNamespace.Cards
{
    public interface IVisitableCard
    {
        void Accept(ICardVisitor visitor);
    }
}