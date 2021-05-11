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
            StartCoroutine(Grow());
        }

        public abstract bool TryEnter(Hero hero);

        public void OnMouseDown()
        {
            if (Game.Hero.IsMoving)
            {
                return;
            }
            var pos = Game.GetCardPosition(this);
            if (IsAdjacent(Game.Hero))
            {
                if (TryEnter(Game.Hero))
                {
                    Destroy(this.GetComponent<BoxCollider2D>());
                    // Game.SwapCards(this, Game.Hero);
                    Game.MoveHero(this);
                }
            }
        }
        
        public void Remove()
        {
            StartCoroutine(Shrink());
        }

        public virtual void Move(Vector2 from, Vector2 to)
        {
            StartCoroutine(MoveTo(from, to));
        }
        
        private IEnumerator Shrink()
        {
            var scale = transform.localScale;
            for (float i = 0; i < 1; i+=Time.deltaTime * 4)
            {
                transform.localScale = Vector3.Lerp(scale, Vector3.zero, i);
                yield return null;
            }
            Destroy(this.gameObject);
        }

        private IEnumerator Grow()
        {
            for (float i = 0; i < 1; i+=Time.deltaTime * 4)
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i);
                yield return null;
            }
            transform.localScale = Vector3.one;
        }

        protected virtual IEnumerator MoveTo(Vector2 from, Vector2 to)
        {
            var fromV3 = new Vector3(from.x, from.y, 0);
            var toV3 = new Vector3(to.x, to.y, 0);
            for (float i = 0; i < 1; i+=Time.deltaTime * 4)
            {
                transform.position = Vector3.Lerp(fromV3, toV3, i);
                yield return null;
            }
            transform.position = toV3;
        }

        private void Swap()
        {
            Game.SwapCards(this, Game.Hero);
        }
    }
}