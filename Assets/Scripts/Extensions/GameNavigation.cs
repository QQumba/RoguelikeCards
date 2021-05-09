using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class GameNavigation
    {
        //TODO handle exceptions in navigation methods if given card not in _cards
        //Game field presented as array of cards.
        //Card presented as square field with side size of _sideSize
        //Example:
        // 6 7 8             6  bottom        8
        // 3 4 5          left    card    right
        // 0 1 2             0     top        2
        public static Card Top(this Game game, Card card)
        {
            var index = GetGameCardIndex(game, card);
            return Top(game, index);
        }

        public static Card Top(this Game game, int index)
        {
            var newIndex = index + game.SideSize;
            return IsCardIndexInbound(game, newIndex) ? game.Cards[newIndex] : null;
        }

        public static Card Bottom(this Game game, Card card)
        {
            var index = GetGameCardIndex(game, card);
            return Bottom(game, index);
        }
        
        public static Card Bottom(this Game game, int index)
        {
            var newIndex = index - game.SideSize;
            return IsCardIndexInbound(game, newIndex) ? game.Cards[newIndex] : null;
        }
        
        public static Card Left(this Game game, Card card)
        {
            var index = GetGameCardIndex(game, card);
            return Left(game, index);
        }
        
        public static Card Left(this Game game, int index)
        {
            if (index % game.SideSize == 0)
            {
                return null;
            }
            var newIndex = index - 1;
            return IsCardIndexInbound(game, newIndex) ? game.Cards[newIndex] : null;
        }
        
        public static Card Right(this Game game, Card card)
        {
            var index = GetGameCardIndex(game, card);
            return Right(game, index);
        }
        
        public static Card Right(this Game game, int index)
        {
            var newIndex = index + 1;
            if (newIndex % game.SideSize == 0)
            {
                return null;
            }
            return IsCardIndexInbound(game, newIndex) ? game.Cards[newIndex] : null;
        }

        public static int GetGameCardIndex(this Game game, Card card)
        {
            var index = Array.IndexOf(game.Cards, card);
            if (index == -1) throw new InvalidCardException();
            return index;
        }
        
        public static Vector2 GetCardPosition(this Game game, Card card)
        {
            var index = GetGameCardIndex(game, card);
            return GetCardPosition(game, index);
        }
        
        public static Vector2 GetCardPosition(this Game game, int cardIndex)
        {
            var position = new Vector2(cardIndex % game.SideSize, (int)(cardIndex / game.SideSize));
            return position;
        }

        public static bool IsCardIndexInbound(this Game game, int index)
        {
            return index >= 0 && index < game.Cards.Length;
        }
    }
}