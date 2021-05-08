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
                    Game.SwapCards(this, Game.Hero);
                    StartCoroutine(nameof(Shrink));
                    MoveHero();
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

        private void MoveHero()
        {
            if (Game.Hero.Top == this)
            {
                StartCoroutine(nameof(MoveTop));
            }
            if (Game.Hero.Bottom == this)
            {
                StartCoroutine(nameof(MoveBottom));
            }
            if (Game.Hero.Left == this)
            {
                StartCoroutine(nameof(MoveLeft));
            }
            if (Game.Hero.Right == this)
            {
                StartCoroutine(nameof(MoveRight));
            }
        }
        
        private IEnumerator MoveTop()
        {
            var position = this.Game.Hero.transform.position;
            for (float i = 0f; i <= 1; i += 0.01f)
            {
                var move = new Vector3(0, i, 0);
                this.Game.Hero.transform.position = position - move; 
                yield return new WaitForSeconds(.0001f);
            }
            // Game.SwapCards(Game.Hero, this);
        }
        
        private IEnumerator MoveBottom()
        {
            var position = this.Game.Hero.transform.position;
            for (float i = 0f; i <= 1; i += 0.01f)
            {
                var move = new Vector3(0, i, 0);
                this.Game.Hero.transform.position = position + move; 
                yield return new WaitForSeconds(.0001f);
            }
            // Game.SwapCards(Game.Hero, this);
        }
        
        private IEnumerator MoveLeft()
        {
            var position = this.Game.Hero.transform.position;
            for (float i = 0f; i <= 1; i += 0.01f)
            {
                var move = new Vector3(i, 0, 0);
                this.Game.Hero.transform.position = position + move; 
                yield return new WaitForSeconds(.0001f);
            }
            // Game.SwapCards(Game.Hero, this);
        }
        
        private IEnumerator MoveRight()
        {
            var position = this.Game.Hero.transform.position;
            for (float i = 0f; i <= 1; i += 0.01f)
            {
                var move = new Vector3(i, 0, 0);
                this.Game.Hero.transform.position = position - move; 
                yield return new WaitForSeconds(.0001f);
            }
            // Game.SwapCards(Game.Hero, this);
        }
        
        private IEnumerator Shrink()
        {
            for (float i = 1f; i >= 0; i -= 0.01f)
            {
                var currentScale = new Vector2(i, i);
                transform.localScale = currentScale;
                yield return new WaitForSeconds(.0001f);
                // Delete();
            }
            
        }
    }
}