using System;
using RoguelikeCards.Cards;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.InputHandlers
{
    public class InputHandler
    {
        private readonly Camera _mainCamera;
        private CardAnimator _animator;

        public InputHandler(Camera mainCamera, CardAnimator animator)
        {
            Debug.Log("Create instance of input handler");
            _mainCamera = mainCamera;
            _animator = animator;
        }

        public event EventHandler<CardEventArgs> CardClicked;

        public void HandleInput()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            // if (_animator.IsAnimating) return;
            
            var hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Card card;
            if (hit.collider != null && (card = hit.collider.GetComponent<Card>()) != null)
            {
                CardClicked?.Invoke(this, new CardEventArgs(card));
            }
        }
    }
}