using RoguelikeCards.Cards;
using RoguelikeCards.RCEventArgs;

namespace RoguelikeCards.EventHandlers
{
    public class CardEventListener
    {
        private readonly Game _game;
        private readonly CardAnimator _animator;
        private readonly DamageableEventListener _damageableEventListener;
        private readonly EnemyEventListener _enemyEventListener;
        private readonly PickableEventListener _pickableEventListener;

        private Card _selectedCard;

        public CardEventListener(Game game, CardAnimator animator)
        {
            _game = game;
            _animator = animator;
            _damageableEventListener = new DamageableEventListener(game, animator);
            _enemyEventListener = new EnemyEventListener(game, animator);
            _pickableEventListener = new PickableEventListener(game, animator);
        }

        public void Subscribe(Card card)
        {
            SubscribeCard(card);

            foreach (var visitable in card.Content.CardComponents)
            {
                
            }
            
            if (card is IDamageable damageable)
            {
                _damageableEventListener.Subscribe(damageable);
            }

            if (card is IEnemy enemy)
            {
                _enemyEventListener.Subscribe(enemy);
            }

            if (card is IPickable pickable)
            {
                _pickableEventListener.Subscribe(pickable);   
            }
        }

        private void SubscribeCard(Card card)
        {
            card.Selected += OnCardSelected;
            card.Destroyed += OnCardDestroyed;
        }

        private void OnCardSelected(object sender, CardEventArgs e)
        {
            _selectedCard = e.Card;
        }

        private void OnCardDestroyed(object sender, CardEventArgs e)
        {
            if (e.Card != _selectedCard)
            {
                _game.ReplaceCard(e.Card);
                return;
            }

            _game.MoveHero(e.Card);
            _game.RemoveCard(e.Card);
        }
    }

    internal class DamageableEventListener
    {
        private readonly Game _game;
        private readonly CardAnimator _animator;

        public DamageableEventListener(Game game, CardAnimator animator)
        {
            _game = game;
            _animator = animator;
        }

        public void Subscribe(IDamageable damageable)
        {
            damageable.DamageApplied += OnDamageApplied;
        }

        private void OnDamageApplied(DamageAppliedEventArgs e)
        {
            _animator.PulseIn(e.Card);
        }
    }

    public class EnemyEventListener
    {
        private readonly Game _game;
        private readonly CardAnimator _animator;

        public EnemyEventListener(Game game, CardAnimator animator)
        {
            _game = game;
            _animator = animator;
        }

        public void Subscribe(IEnemy damageable)
        {
            damageable.Died += OnDied;
        }

        private void OnDied(CardEventArgs e)
        {
            _animator.Shrink(e.Card);
        }
    }

    public class PickableEventListener
    {
        private readonly Game _game;
        private readonly CardAnimator _animator;

        public PickableEventListener(Game game, CardAnimator animator)
        {
            _game = game;
            _animator = animator;
        }

        public void Subscribe(IPickable pickable)
        {
            pickable.PickedUp += OnPickedUp;
        }

        private void OnPickedUp(object sender, CardEventArgs e)
        {
            _animator.Rotate(e.Card);
        }
    }
}