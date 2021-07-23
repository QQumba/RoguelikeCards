using System;
using UnityEngine;

namespace DefaultNamespace.Cards.InputHandlers
{
    public class InputHandler
    {
        private readonly Camera _mainCamera;
        private CardAnimator _animator;

        public InputHandler(Camera mainCamera)
        {
            _mainCamera = mainCamera;
            _animator = CardAnimator.GetInstance();
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