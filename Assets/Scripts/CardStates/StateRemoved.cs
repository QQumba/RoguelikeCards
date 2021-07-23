using DefaultNamespace.Cards;

namespace DefaultNamespace.CardStates
{
    public class StateRemoved : CardState
    {
        private readonly Card _card;
        public StateRemoved(Card card)
        {
            _card = card;
        }

        public override CardState Update()
        {
            return this;
        }
    }
}