using DefaultNamespace.Cards;
using DefaultNamespace.Cards.Heroes;
using TMPro;

namespace DefaultNamespace.CardStates
{
    public class StateDamaged : CardState
    {
        private readonly IDamageable _damageable;
        private CardAnimator _animator;

        public StateDamaged(IDamageable damageable)
        {
            _damageable = damageable;
            _animator = CardAnimator.GetInstance();
        }

        public override CardState Update()
        {
            _animator.PulseIn(_damageable as Card);
            return new StateIdle(_damageable as Card);
        }
    }
}