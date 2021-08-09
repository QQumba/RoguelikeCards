using RoguelikeCards.Cards;

namespace RoguelikeCards.CardStates
{
    public class StateCreated : CardState
    {
        private readonly Card _card;
        private readonly CardAnimator _animator;

        public StateCreated(Card card)
        {
            _card = card;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            _animator.Grow(_card);
            return new StateIdle(_card);
        }
    }
}