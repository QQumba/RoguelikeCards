using DefaultNamespace.Cards;
using DefaultNamespace.Cards.Heroes;
using UnityEngine;

namespace DefaultNamespace.CardStates
{
    public class StateEntered : CardState
    {
        private readonly Game _game;
        private readonly Card _card;
        private readonly CardAnimator _animator;

        public StateEntered(Card card, Game game)
        {
            _card = card;
            _game = game;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            _animator.Shrink(_card);
            _game.MoveHero(_card);
            return new StateRemoved(_card);
        }
    }
}