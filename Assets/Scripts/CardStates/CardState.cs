using DefaultNamespace.Cards;
using DefaultNamespace.Cards.Heroes;

namespace DefaultNamespace.CardStates
{
    public abstract class CardState
    {
        public abstract CardState Update();
    }
}