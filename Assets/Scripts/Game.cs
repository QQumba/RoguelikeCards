using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Cards
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameField gameField;
        [SerializeField] private ValueChangedEvent turnCompleted;

        private Queue<Card> _removedCardPool;
        private int _cardToRemove;

        private CardAnimator _animator;

        private int _turnCount;

        private void Start()
        {
            _animator = CardAnimator.GetInstance();
            _removedCardPool = new Queue<Card>();
        }

        public Hero Hero { get; set; }

        private void UpdateCards()
        {
            
        }

        private void UpdateGameField()
        {
        }

        private void Animate()
        {
        }

        public void CompleteTurn()
        {
            foreach (var card in gameField.Cards)
            {
                card.TurnUpdate();
                card.UpdateState();
            }

            for (int i = 0; i < _removedCardPool.Count - _cardToRemove; i++)
            {
                var card = _removedCardPool.Dequeue();
                Destroy(card.gameObject);
            }

            _turnCount++;
            _cardToRemove = 0;
            turnCompleted.Invoke(_turnCount);
        }

        public void MoveHero(Card card)
        {
            _removedCardPool.Enqueue(card);
            _cardToRemove++;
            
            _animator.Move(Hero, card);
            
            gameField.MoveCard(Hero, card);
        }

        public void ReplaceCard(Card card)
        {
            _removedCardPool.Enqueue(card);
            _cardToRemove++;
            gameField.ReplaceCard(card);
        }
    }

    [Serializable]
    public class ValueChangedEvent : UnityEvent<int> { }
}