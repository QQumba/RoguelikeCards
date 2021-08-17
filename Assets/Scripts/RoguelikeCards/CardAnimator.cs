using System;
using System.Collections;
using RoguelikeCards.Cards;
using RoguelikeCards.EventHandlers;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace RoguelikeCards
{
    public class CardAnimator : MonoBehaviour
    {
        [SerializeField] private SwordSlash slash;
        [SerializeField] private int animationSpeedMultiplier = 1;
        [SerializeField] private AnimationCurve pulseInCurve;

        private static CardAnimator _instance;
        private readonly AnimationQueue _queue = new AnimationQueue();

        public bool IsAnimating => _queue.HasActiveAnimations;

        public event Action AnimationCompleted;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Start()
        {
            _queue.QueueEmptied += () => AnimationCompleted?.Invoke();
        }

        /// <summary>
        /// Always return null
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public static CardAnimator GetInstance()
        {
            return null;
        }

        public void Grow(Card card)
        {
            StartCoroutine(Grow(card.transform));
        }

        public void Shrink(Card card)
        {
            StartCoroutine(Shrink(card.transform));
        }

        public void Rotate(Card card)
        {
            // TODO: deal with strange coroutine call
            StartCoroutine(Rotate(card, 0, 90));
        }

        public void Move(Card from, Card to)
        {
            StartCoroutine(Move(from.transform, to.transform));
        }

        public void PulseIn(Card card)
        {
            slash.Play(card);
            StartCoroutine(PulseIn(card.transform));
        }

        private IEnumerator Grow(Transform t)
        {
            _queue.Enqueue();
            for (float i = 0; i < 1; i += Time.deltaTime * 4 * animationSpeedMultiplier)
            {
                t.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i);
                yield return null;
            }

            t.localScale = Vector3.one;
            _queue.Dequeue();
        }

        private IEnumerator Shrink(Transform t)
        {
            _queue.Enqueue();
            var scale = t.localScale;
            for (float i = 0; i < 1; i += Time.deltaTime * 4 * animationSpeedMultiplier)
            {
                t.localScale = Vector3.Lerp(scale, Vector3.zero, i);
                yield return null;
            }

            t.localScale = Vector3.zero;
            _queue.Dequeue();
        }


        // rotate card on: 0 -> 90 (90), 90 -> 270 (180), 270 -> 360 (90)
        // TODO: udolit' kostil'
        private IEnumerator Rotate(Card card, int fromAngle, int toAngle)
        {
            var t = card.transform;
            
            _queue.Enqueue();
            for (float i = 0; i < 1; i += Time.deltaTime * 2 * animationSpeedMultiplier * 3)
            {
                t.eulerAngles = new Vector3(0, Mathf.Lerp(fromAngle, toAngle, i), 0);
                yield return null;
            }

            var angleDifference = toAngle - fromAngle;
            
            if (toAngle == 360)
            {

            }
            else if (angleDifference == 90)
            {
                card.Destroy();
                card.Content.Hide();
                StartCoroutine(Rotate(card, toAngle, toAngle + 180));
            }
            else if (angleDifference == 180)
            {
                card.Content.Show();
                StartCoroutine(Rotate(card, toAngle, toAngle + 90));
            }

            _queue.Dequeue();
        }

        private IEnumerator Move(Transform from, Transform to)
        {
            _queue.Enqueue();
            var fromPosition = from.position;
            var toPosition = to.position;
            for (float i = 0; i < 1; i += Time.deltaTime * 4 * animationSpeedMultiplier)
            {
                from.position = Vector3.Lerp(fromPosition, toPosition, i);
                yield return null;
            }

            from.position = toPosition;
            _queue.Dequeue();
        }

        private IEnumerator PulseIn(Transform t)
        {
            _queue.Enqueue();
            for (float i = 0; i < 1; i += Time.deltaTime * 4 * animationSpeedMultiplier)
            {
                var scale = pulseInCurve.Evaluate(i);
                t.localScale = new Vector3(scale, scale, scale);
                yield return null;
            }

            var finalScale = pulseInCurve.Evaluate(0);
            t.localScale = new Vector3(finalScale, finalScale, finalScale);
            _queue.Dequeue();
        }
    }
}