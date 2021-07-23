using DefaultNamespace.Cards;
using DefaultNamespace.Cards.Heroes;

namespace DefaultNamespace.CardStates
{
    public class StateMoved : CardState
    {
        private Card _card;
        private Card _destinationCard;
        private CardAnimator _animator;

        public StateMoved(Card card, Card destinationCard)
        {
            _card = card;
            _destinationCard = destinationCard;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            _animator.Move(_card, _destinationCard);
            return new StateIdle(_card);
        }
    }
}