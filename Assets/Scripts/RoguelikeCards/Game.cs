using System;
using System.Collections.Generic;
using RoguelikeCards.Cards;
using RoguelikeCards.EventHandlers;
using RoguelikeCards.Heroes;
using RoguelikeCards.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

namespace RoguelikeCards
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameField gameField;
        [SerializeField] private StringValueChangedEvent turnCompleted;
        [SerializeField] private CardAnimator animator;

        private Queue<Card> _removedCardPool;
        private int _cardToRemove;
        private CardEventListener _cardEventListener;

        private int _turnCount;

        private void Awake()
        {
            _cardEventListener = new CardEventListener(this, animator);
        }

        private void Start()
        {
            _removedCardPool = new Queue<Card>();
        }

        private void OnEnable()
        {
            gameField.CardCreated += OnCardCreated;
        }

        private void OnDisable()
        {
            gameField.CardCreated -= OnCardCreated;
        }

        public Hero Hero { get; set; }

        public void CompleteTurn()
        {
            foreach (var card in gameField.Cards)
            {
                card.TurnUpdate();
            }
            turnCompleted.Invoke(_turnCount.ToString());
            RemoveCards();
        }

        public void MoveHero(Card card)
        {
            animator.Move(Hero, card);
            gameField.MoveCard(Hero, card);
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

        private void OnCardCreated(Card card)
        {
            animator.Grow(card);
            _cardEventListener.Subscribe(card);
        }
    }
}