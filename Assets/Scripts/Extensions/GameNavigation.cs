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
            var currentCardIndex = GetGameCardIndex(game, card);
            Debug.Log($"clicked card index: {currentCardIndex}");
            Debug.Log($"top card index: {currentCardIndex}");
            var index = currentCardIndex + game.SideSize;
            return IsCardIndexInbound(game, index) ? game.Cards[index] : null;
        }
 
        public static Card Bottom(this Game game, Card card)
        {
            var currentCardIndex = GetGameCardIndex(game, card);
            var index = currentCardIndex - game.SideSize;
            return IsCardIndexInbound(game, index) ? game.Cards[index] : null;
        }
        
        public static Card Left(this Game game, Card card)
        {
            var currentCardIndex = GetGameCardIndex(game, card);
            if (currentCardIndex % game.SideSize == 0)
            {
                return null;
            }
            var index = currentCardIndex - 1;
            return IsCardIndexInbound(game, index) ? game.Cards[index] : null;
        }
        
        public static Card Right(this Game game, Card card)
        {
            var currentCardIndex = GetGameCardIndex(game, card);
            var index = currentCardIndex + 1;
            if (index % game.SideSize == 0)
            {
                return null;
            }
            return IsCardIndexInbound(game, index) ? game.Cards[index] : null;
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

        private static bool IsCardIndexInbound(this Game game, int index)
        {
            return index >= 0 && index < game.Cards.Length;
        }
    }
}