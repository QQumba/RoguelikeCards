using System;
using System.Numerics;
using DefaultNamespace.Powerups;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Card : MonoBehaviour
    {
        public Game Game;

        public Card Top => Game.Top(this);
        public Card Bottom => Game.Bottom(this);
        public Card Left => Game.Left(this);
        public Card Right => Game.Right(this);

        public bool IsAdjacent(Card card)
        {
            return card == Top || card == Bottom || card == Left || card == Right;
        }

        public abstract bool TryEnter(Hero hero);

        private void OnMouseDown()
        {
            if (Game != null)
            {
                Debug.Log($"ne sosi");
            }
            var pos = Game.GetCardPosition(this);
            Debug.Log($"clicked on card");
            Debug.Log($"card position: {pos.x}.{pos.y}");
            Debug.Log($"index: {Game.GetGameCardIndex(this)}");
            if (IsAdjacent(Game.Hero))
            {
                if (TryEnter(Game.Hero))
                {
                    Debug.Log($"enter in card");
                    if (Game == null)
                    {
                        Debug.Log($"sosi");
                    }
                    if (Game.Hero == null)
                    {
                        Debug.Log($"sosi1");
                    }
                    Debug.Log($"card position: {Game.GetCardPosition(this)}");
                    Debug.Log($"hero position: {Game.GetCardPosition(Game.Hero)}");
                    Game.SwapCards(this, Game.Hero);
                }
            }
        }


        public void Delete()
        {
            Destroy(this.gameObject);
        } 
    }
}