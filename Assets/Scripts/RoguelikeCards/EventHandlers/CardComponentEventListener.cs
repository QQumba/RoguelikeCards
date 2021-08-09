using RoguelikeCards.Cards;
using RoguelikeCards.Heroes;

namespace RoguelikeCards.EventHandlers
{
    public class CardComponentEventListener : ICardComponentVisitor
    {
        private readonly CardAnimator _animator;

        public CardComponentEventListener(CardAnimator animator)
        {
            _animator = animator;
        }

        public void Visit(IEnemy enemy)
        {
            enemy.Died += e =>
            {
                _animator.Shrink(e.Card);
            };
        }

        public void Visit(IDamageable damageable)
        {
            damageable.DamageApplied += e =>
            {
                _animator.PulseIn(e.Card);
            };
        }

        public void Visit(Card card)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(IPickable pickable)
        {
            
        }
    }
}