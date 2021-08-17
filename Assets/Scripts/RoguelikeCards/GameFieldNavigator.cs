using System;
using System.Collections.Generic;
using System.Linq;
using RoguelikeCards.Cards;
using RoguelikeCards.Heroes;
using UnityEngine;

namespace RoguelikeCards
{
    [RequireComponent(typeof(GameField))]
    public class GameFieldNavigator : MonoBehaviour
    {
        private GameField _gameField;

        private Hero _hero;

        public Hero Hero => GetHero();

        private void Awake()
        {
            _gameField = GetComponent<GameField>();
        }

        public List<TComponent> GetCardComponents<TComponent>()
        {
            var cards = new List<TComponent>();
            foreach (var card in _gameField.Cards)
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

            foreach (var card in _gameField.Cards)
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