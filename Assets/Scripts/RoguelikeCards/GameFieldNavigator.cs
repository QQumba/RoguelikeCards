using System;
using System.Collections.Generic;
using System.Linq;
using RoguelikeCards.Cards;
using RoguelikeCards.Extensions;
using RoguelikeCards.Heroes;
using UnityEngine;

namespace RoguelikeCards
{
    public class GameFieldNavigator
    {
        private readonly Card[] _cards;
        private Hero _hero;

        public GameFieldNavigator(Card[] cards)
        {
            _cards = cards;
        }

        public Hero Hero => GetHero();
        
        public Card Top(Card card)
        {
            return _cards.Top(card);
        }
        
        public Card Right(Card card)
        {
            return _cards.Right(card);
        }
        
        public Card Bottom(Card card)
        {
            return _cards.Bottom(card);
        }
        
        public Card Left(Card card)
        {
            return _cards.Left(card);
        }

        public List<TComponent> GetCardComponents<TComponent>()
        {
            var cards = new List<TComponent>();
            foreach (var card in _cards)
            {
                foreach (var component in card.Content.CardComponents)
                {
                    if (component is TComponent c)
                    {
                        cards.Add(c);
                    }
                }
            }

            return cards;
        }

        private Hero GetHero()
        {
            if (_hero != null)
            {
                return _hero;
            }

            foreach (var card in _cards)
            {
                foreach (var component in card.Content.CardComponents)
                {
                    if (component is Hero hero)
                    {
                        _hero = hero;
                        return _hero;
                    }
                }
            }

            Debug.Log("Hero not found");
            return _hero;
        }
    }
}