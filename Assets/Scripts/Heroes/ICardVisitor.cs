namespace DefaultNamespace.Cards.Heroes
{
    public interface ICardVisitor
    {
        void Visit(Card card);
        void Visit(IPickable pickable);
        void Visit(IEnemy enemy);
    }
}