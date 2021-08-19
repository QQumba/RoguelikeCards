using System;
using RoguelikeCards.EventDispatcher;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private Sprite highlighted;

        private SpriteRenderer _renderer;

        public event Action<CardEventArgs> Destroyed;
        public event Action<CardEventArgs> Entered;

        public CardContent Content { get; set; }
        public GameFieldNavigator Navigator { get; set; }
        public IDispatcher Dispatcher { get; set; }

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            _renderer.sprite = highlighted;
        }

        private void OnMouseExit()
        {
            _renderer.sprite = defaultSprite;
        }

        public void Accept(ICardComponentVisitor visitor)
        {
            foreach (var visitable in Content.CardComponents)
            {
                visitable.Accept(visitor);
            }
        }

        public void Destroy()
        {
            var oldContent = Content;
            Content = oldContent.Loot.GetInstance(this);
            oldContent.Hide();
            Destroyed?.Invoke(this);
        }

        public void Accept()
        {
            Entered?.Invoke(this);
        } 
    }
}