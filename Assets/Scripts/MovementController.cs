using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DefaultNamespace.Cards.InputHandlers;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameField field;
        [SerializeField] private Game game;

        private Queue<Card> _turnQueue;
        private Hero _hero;
        private InputHandler _inputHandler;
        private CardAnimator _animator;
        
        private void Start()
        {
            _hero = field.GetCards<Hero>().Single();
            _inputHandler = new InputHandler(mainCamera);
            _inputHandler.CardClicked += OnCardClicked;
            _turnQueue = new Queue<Card>();
            _animator = CardAnimator.GetInstance();
        }

        private void OnEnable()
        {
            if (_inputHandler != null)
            {
                _inputHandler.CardClicked += OnCardClicked;
            }
        }

        private void OnDisable()
        {
            _inputHandler.CardClicked -= OnCardClicked;
        }

        private void Update()
        {
            _inputHandler.HandleInput();

            if (_animator.IsAnimating)
            {
                return;
            }

            if (_turnQueue.Any() == false)
            {
                return;
            }
            
            _turnQueue.Dequeue().Accept(_hero);
            game.CompleteTurn();
        }

        private void OnCardClicked(object sender, CardEventArgs e)
        {
            Debug.Log($"turn queue lenght: {_turnQueue.Count}");
            
            if (_turnQueue.Count == 0)
            {
                if (field.IsCardsAdjacent(_hero, e.Card))
                {
                    _turnQueue.Enqueue(e.Card);
                    return;
                }
            }

            if (_turnQueue.Count == 1)
            {
                var enqueuedCard = _turnQueue.Peek(); 
                if (enqueuedCard != e.Card && field.IsCardsAdjacent(enqueuedCard, e.Card))
                {
                    _turnQueue.Enqueue(e.Card);
                }
            }
        }
    }
}