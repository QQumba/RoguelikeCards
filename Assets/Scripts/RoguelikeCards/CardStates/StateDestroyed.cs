using RoguelikeCards.Cards;

namespace RoguelikeCards.CardStates
{
    public class StateDestroyed : CardState
    {
        // TODO remove game 
        private readonly Game _game;
        private readonly Card _card;
        private readonly CardAnimator _animator;

        public StateDestroyed(Card card, Game game)
        {
            _card = card;
            _game = game;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            // TODO rotate instead of shrink
            _animator.Shrink(_card);
            _game.ReplaceCard(_card);
            return new StateRemoved(_card);
        }
    }
}