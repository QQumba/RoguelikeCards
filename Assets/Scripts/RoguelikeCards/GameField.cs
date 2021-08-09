using System;
using System.Collections.Generic;
using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private int sideSize;
        [SerializeField] private GameFieldInitializer initializer;

        public event Action GameFieldInitialized;
        public event Action<Card> CardCreated;
        
        public Card[] Cards { get; private set; }

        private void Awake()
        {
            Cards = new Card[sideSize * sideSize];
        }

        private void Start()
        {
            initializer.CardCreated += c => { CardCreated?.Invoke(c);};
            initializer.InitializeGameField(Cards, sideSize);
            GameFieldInitialized?.Invoke();
            // foreach (var card in Cards)
            // {
            //     card.UpdateState();
            // }
        }

        public List<TCard> GetCards<TCard>()
        {
            var cards = new List<TCard>();
            foreach (var card in Cards)
            {
                TCard t;
                if ((t = card.GetComponent<TCard>()) != null)
                {
                    cards.Add(t);
                }
            }

            return cards;
        }

        public bool IsCardsAdjacent(Card first, Card second)
        {
            return Top(first) == second
                   || Right(first) == second
                   || Bottom(first) == second
                   || Left(first) == second;
        }

        public Card Top(Card card)
        {
            var index = GetCardIndex(card);
            return Top(index);
        }

        public Card Top(int index)
        {
            var newIndex = index + sideSize;
            return IsCardIndexInbound(newIndex) ? Cards[newIndex] : null;
        }

        public Card Bottom(Card card)
        {
            var index = GetCardIndex(card);
            return Bottom(index);
        }

        private Card Bottom(int index)
        {
            var newIndex = index - sideSize;
            return IsCardIndexInbound(newIndex) ? Cards[newIndex] : null;
        }

        public Card Left(Card card)
        {
            var index = GetCardIndex(card);
            return Left(index);
        }

        private Card Left(int index)
        {
            if (index % sideSize == 0)
            {
                return null;
            }

            var newIndex = index - 1;
            return IsCardIndexInbound(newIndex) ? Cards[newIndex] : null;
        }

        public Card Right(Card card)
        {
            var index = GetCardIndex(card);
            return Right(index);
        }

        private Card Right(int index)
        {
            var rightCardIndex = index + 1;
            if (rightCardIndex % sideSize == 0)
            {
                return null;
            }

            return IsCardIndexInbound(rightCardIndex) ? Cards[rightCardIndex] : null;
        }

        public Vector2 GetCardPosition(Card card)
        {
            var index = GetCardIndex(card);
            return GetCardPosition(index);
        }

        private Vector2 GetCardPosition(int cardIndex)
        {
            var position = new Vector2(cardIndex % sideSize, cardIndex / sideSize);
            return position;
        }

        public void MoveCard(Card from, Card to)
        {
            var fromIndex = GetCardIndex(from);
            var toIndex = GetCardIndex(to);

            if (IsCardIndexInbound(fromIndex) == false)
            {
                return;
            }
            var card = Cards[fromIndex];

            Cards[toIndex] = card;
            Cards[fromIndex] = null;
            initializer.UpdateGameField(Cards);
        }

        private int GetCardIndex(Card card)
        {
            var index = Array.IndexOf(Cards, card);
            if (index == -1) throw new ArgumentException();
            return index;
        }

        private bool IsCardIndexInbound(int index)
        {
            return index >= 0 && index < Cards.Length;
        }

        public void ReplaceCard(Card card)
        {
            var index = GetCardIndex(card);
            Cards[index] = null;
            initializer.UpdateGameField(Cards);
        }
    }
}