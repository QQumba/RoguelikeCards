using System;
using TMPro;
using UnityEngine;

namespace RoguelikeCards.Cards
{
    public class CardContent : MonoBehaviour
    {
        [SerializeField] private CardContent loot;

        private SpriteRenderer[] _sprites;
        private TextMeshPro[] _texts;

        public CardComponent[] CardComponents => GetComponents<CardComponent>();
        public ITurnUpdateable TurnUpdateable => GetComponent<ITurnUpdateable>();
        public Card Card { get; private set; }
        public CardContent Loot => loot;

        private void Awake()
        {
            _sprites = GetComponentsInChildren<SpriteRenderer>();
            _texts = GetComponentsInChildren<TextMeshPro>();
        }

        public CardContent GetInstance(Card card)
        {
            var content = Instantiate(this, card.transform);
            content.Card = card;
            return content;
        }

        public void Show()
        {
            ToggleVisibility(true);
        }

        public void Hide()
        {
            ToggleVisibility(false);
        }

        private void ToggleVisibility(bool isVisible)
        {
            _sprites ??= GetComponentsInChildren<SpriteRenderer>();
            _texts ??= GetComponentsInChildren<TextMeshPro>();
            
            foreach (var sprite in _sprites)
            {
                sprite.enabled = isVisible;
            }

            foreach (var text in _texts)
            {
                text.enabled = isVisible;
            }
        }
    }
}