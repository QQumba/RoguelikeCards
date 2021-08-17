using System.Collections.Generic;
using System.Linq;
using RoguelikeCards.Cards;
using RoguelikeCards.Extensions;
using RoguelikeCards.Heroes;
using RoguelikeCards.InputHandlers;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameField field;
        [SerializeField] private Game game;
        [SerializeField] private CardAnimator animator;

        private Queue<Card> _turnQueue;
        private Hero _hero;
        private InputHandler _inputHandler;

        private void Awake()
        {
            _inputHandler = new InputHandler(mainCamera, animator);
            _inputHandler.CardClicked += OnCardClicked;
            _turnQueue = new Queue<Card>();
        }

        private void Start()
        {
            _hero = field.GetCardComponents<Hero>().Single();
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

            if (animator.IsAnimating)
            {
                return;
            }

            if (_turnQueue.Count == 0)
            {
                return;
            }
            
            _turnQueue.Dequeue().Accept(_hero);
            game.CompleteTurn();
        }

        private void OnCardClicked(object sender, CardEventArgs e)
        {
            // TODO issue: allow player to move on card after moved on other spot            
            if (_turnQueue.Count == 0)
            {
                if (field.Cards.IsCardsAdjacent(_hero.Card, e.Card))
                {
                    _turnQueue.Enqueue(e.Card);
                    return;
                }
            }

            if (_turnQueue.Count == 1)
            {
                var enqueuedCard = _turnQueue.Peek(); 
                if (enqueuedCard != e.Card && field.Cards.IsCardsAdjacent(enqueuedCard, e.Card))
                {
                    _turnQueue.Enqueue(e.Card);
                }
            }
        }
    }
}