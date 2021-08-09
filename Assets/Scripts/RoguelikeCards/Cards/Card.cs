using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards
{
    public abstract class Card : MonoBehaviour
    {
        [SerializeField] private CardContent content;

        public CardContent Content => content;
        protected Game Game { get; set; }

        public event EventHandler<CardEventArgs> Destroyed;
        public event EventHandler<CardEventArgs> Selected;

        private void Start()
        {
            Instantiate(content, transform);
        }

        public void Accept(ICardComponentVisitor visitor)
        {
            foreach (var visitable in content.CardComponents)
            {
                visitable.Accept(visitor);
            }
            Selected?.Invoke(this, this);
            AcceptHero(visitor);
        }

        protected virtual void AcceptHero(ICardComponentVisitor cardComponentVisitor) { }

        public Card GetInstance(Game game)
        {
            return GetInstanceOf(this, game);
        }

        private Card GetInstanceOf(Card card, Game game)
        {
            var instance = Instantiate(card, transform.position, Quaternion.identity);

            instance.transform.localScale = Vector3.zero;
            instance.Game = game;
            return instance;
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this,this);
        }

        public virtual void TurnUpdate() { }
    }
}