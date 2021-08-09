using RoguelikeCards.Cards;

namespace RoguelikeCards.CardStates
{
    public class StateIdle : CardState
    {
        private CardAnimator _animator;
        private Card _card;
        
        public StateIdle(Card card)
        {
            _card = card;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            return this;
        }
    }
}