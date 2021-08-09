using RoguelikeCards.Cards;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.EventHandlers
{
    public class DamageableEventHandler
    {
        private static readonly CardAnimator Animator;

        static DamageableEventHandler()
        {
            Animator = CardAnimator.GetInstance();
        }

        public void Subscribe(IDamageable damageable)
        {
            damageable.DamageApplied += OnDamageTaken;
        }

        public void Unsubscribe(IDamageable damageable)
        {
            damageable.DamageApplied -= OnDamageTaken;
        }

        private void OnDamageTaken(DamageAppliedEventArgs e)
        {
            Animator.PulseIn(e.Card);
        }
        
        public static void OnDamageTakenStatic(object sender, DamageAppliedEventArgs e)
        {
            if (sender is Card card)
            {
                Animator.PulseIn(card);
            }
        }
    }
}