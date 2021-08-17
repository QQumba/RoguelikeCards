using System;
using System.Collections;
using System.Collections.Generic;
using RoguelikeCards.Cards;
using UnityEngine;

namespace RoguelikeCards.Extensions
{
    //Card presented as square field with side size of _sideSize
    //Example:
    // 6 7 8             6  bottom        8
    // 3 4 5          left    card    right
    // 0 1 2             0     top        2
    public static class GameNavigation
    {
        public static Vector3 GetCardPosition(this Card[] c, Card card)
        {
            var index = c.GetCardIndex(card);
            return c.GetCardPosition(index);
        }

        public static bool IsCardsAdjacent(this Card[] c, Card first, Card second)
        {
            return c.Top(first) == second
                   || c.Right(first) == second
                   || c.Bottom(first) == second
                   || c.Left(first) == second;
        }

        public static Card Top(this Card[] c, Card card)
        {
            var index = c.GetCardIndex(card);
            return c.Top(index);
        }

        public static Card Right(this Card[] c, Card card)
        {
            var index = c.GetCardIndex(card);
            return c.Right(index);
        }

        public static Card Bottom(this Card[] c, Card card)
        {
            var index = c.GetCardIndex(card);
            return c.Bottom(index);
        }

        public static Card Left(this Card[] c, Card card)
        {
            var index = c.GetCardIndex(card);
            return c.Left(index);
        }

        private static Card Top(this IReadOnlyList<Card> c, int index)
        {
            var newIndex = index + c.GetSideSize();
            return c.GetCardOrNull(newIndex);
        }

        private static Card Right(this IReadOnlyList<Card> c, int index)
        {
            var newIndex = index + 1;
            if (newIndex % c.GetSideSize() == 0)
            {
                return null;
            }

            return c.GetCardOrNull(newIndex);
        }

        private static Card Bottom(this IReadOnlyList<Card> c, int index)
        {
            var newIndex = index - c.GetSideSize();
            return c.GetCardOrNull(newIndex);
        }

        private static Card Left(this IReadOnlyList<Card> c, int index)
        {
            if (index % c.GetSideSize() == 0)
            {
                return null;
            }

            var newIndex = index - 1;
            return c.GetCardOrNull(newIndex);
        }

        public static int GetCardIndex(this Card[] c, Card card)
        {
            var index = Array.IndexOf(c, card);
            if (index == -1) throw new ArgumentException("Card not attached to cards array");
            return index;
        }

        public static Vector3 GetCardPosition(this IReadOnlyCollection<Card> c, int cardIndex)
        {
            var sideSize = c.GetSideSize();
            var position = new Vector2(cardIndex % sideSize, (int) (cardIndex / sideSize));
            return position;
        }

        private static Card GetCardOrNull(this IReadOnlyList<Card> c, int index)
        {
            if (index >= 0 && index < c.Count)
            {
                return c[index];
            }

            return null;
        }

        private static int GetSideSize(this IReadOnlyCollection<Card> c)
        {
            var sideSize = (int) Mathf.Sqrt(c.Count);
            if (sideSize * sideSize != c.Count)
            {
                throw new ArgumentException();
            }

            return sideSize;
        }
    }
}