using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using DefaultNamespace.Powerups;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace DefaultNamespace
{
    public abstract class Card : MonoBehaviour
    {
        public Game Game;

        private bool _isAnimationActive = false;
        
        public Card Top => Game.Top(this);
        public Card Bottom => Game.Bottom(this);
        public Card Left => Game.Left(this);
        public Card Right => Game.Right(this);

        public bool IsAdjacent(Card card)
        {
            return card == Top || card == Bottom || card == Left || card == Right;
        }

        public void AssignToGame(Game game)
        {
            Game = game;
            transform.position = Game.GetCardPosition(this);
        }

        public abstract bool TryEnter(Hero hero);

        public void OnMouseDown()
        {
            if (_isAnimationActive)
            {
                return;
            }
            
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
                    Destroy(this.GetComponent<BoxCollider2D>());
                    // Game.SwapCards(this, Game.Hero);
                    Game.MoveHero(this);
                }
            }
        }
        public void Delete()
        {
            Destroy(this.gameObject);
        }

        private void Swap()
        {
            Game.SwapCards(this, Game.Hero);
        }
    }
}