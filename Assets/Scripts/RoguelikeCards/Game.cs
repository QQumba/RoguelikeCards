using System.Collections.Generic;
using RoguelikeCards.Cards;
using RoguelikeCards.EventHandlers;
using RoguelikeCards.Extensions;
using RoguelikeCards.Heroes;
using RoguelikeCards.UnityEvents;
using UnityEngine;

namespace RoguelikeCards
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameField gameField;
        [SerializeField] private StringValueChangedEvent turnCompleted;
        [SerializeField] private CardAnimator animator;

        private Queue<Card> _removedCardPool;
        private int _cardToRemove;
        private CardComponentEventListener _eventListener;

        private int _turnCount;

        private void Awake()
        {
            _eventListener = new CardComponentEventListener(animator);
        }

        private void Start()
        {
            _removedCardPool = new Queue<Card>();
        }

        private void OnEnable()
        {
            gameField.CardSpawned += OnCardSpawned;
        }

        private void OnDisable()
        {
            gameField.CardSpawned -= OnCardSpawned;
        }

        public Hero Hero { get; set; }

        public void CompleteTurn()
        {
            foreach (var card in gameField.Cards)
            { 
                card.Content?.TurnUpdateable?.Update();
            }

            _turnCount++;
            turnCompleted.Invoke(_turnCount.ToString());
            RemoveCards();
        }

        public void MoveHero(Card card)
        {
            animator.Move(Hero.Card, card);
            gameField.MoveCard(Hero.Card, card);
        }

        public void ReplaceCard(Card card)
        {
            gameField.ReplaceCard(card);
        }

        public void RemoveCard(Card card)
        {
            _removedCardPool.Enqueue(card);
            _cardToRemove++;
        }

        private void RemoveCards()
        {
            for (int i = 0; i < _removedCardPool.Count - _cardToRemove; i++)
            {
                var card = _removedCardPool.Dequeue();
                Destroy(card.gameObject);
            }

            _cardToRemove = 0;
        }

        private void OnCardSpawned(Card card)
        {
            animator.Grow(card);

            foreach (var component in card.Content.CardComponents)
            {
                // TODO: rework hero assigning
                if (component is Hero hero)
                {
                    Hero = hero;
                }
                component.Accept(_eventListener);
            }
            
            card.Entered += e =>
            {
                animator.Move(Hero.Card, e.Card);
                var index = gameField.Cards.GetCardIndex(Hero.Card);
                gameField.ReplaceCard(index);
                gameField.MoveCard(Hero.Card, e.Card);
            };
            
            card.Destroyed += e =>
            {
                e.Card.Accept(_eventListener);    
            };
        }
    }
}