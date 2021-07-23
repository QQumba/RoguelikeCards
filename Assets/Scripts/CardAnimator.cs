using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class CardAnimator : MonoBehaviour
    {
        [SerializeField] private AnimationCurve pulseInCurve;

        private static CardAnimator _instance;
        private int _runningAnimations;

        public bool IsAnimating => _runningAnimations != 0;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        public static CardAnimator GetInstance()
        {
            return _instance;
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
            StartCoroutine(RotateCard(card));
        }

        public void Move(Card from, Card to)
        {
            StartCoroutine(Move(from.transform, to.transform));
        }

        public void PulseIn(Card card)
        {
            StartCoroutine(PulseIn(card.transform));
        }
        
        private IEnumerator Grow(Transform t)
        {
            _runningAnimations++;
            for (float i = 0; i < 1; i += Time.deltaTime * 4)
            {
                t.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i);
                yield return null;
            }

            t.localScale = Vector3.one;
            _runningAnimations--;
        }

        private IEnumerator Shrink(Transform t)
        {
            _runningAnimations++;
            var scale = t.localScale;
            for (float i = 0; i < 1; i += Time.deltaTime * 4)
            {
                t.localScale = Vector3.Lerp(scale, Vector3.zero, i);
                yield return null;
            }

            t.localScale = Vector3.zero;
            _runningAnimations--;
        }

        private IEnumerator RotateCard(Card card)
        {
            _runningAnimations++;
            var t = card.transform;
            for (float i = 0; i < 1; i += Time.deltaTime * 2)
            {
                card.Content.SetActive(true);
                if (card.transform.rotation.eulerAngles.y >= 90 && card.transform.rotation.eulerAngles.y <= 270)
                {
                    card.Content.SetActive(false);
                }
                t.eulerAngles = new Vector3(0, Mathf.Lerp(0, 360, i), 0);
                yield return null;
            }

            t.rotation = Quaternion.identity;
            card.Content.SetActive(true);
            _runningAnimations--;
        }

        private IEnumerator Move(Transform from, Transform to)
        {
            _runningAnimations++;
            var fromPosition = from.position;
            var toPosition = to.position;
            for (float i = 0; i < 1; i += Time.deltaTime * 4)
            {
                from.position = Vector3.Lerp(fromPosition, toPosition, i);
                yield return null;
            }

            from.position = toPosition;
            _runningAnimations--;
        }

        private IEnumerator PulseIn(Transform t)
        {
            _runningAnimations++;
            for (float i = 0; i < 1; i += Time.deltaTime * 4)
            {
                var scale = pulseInCurve.Evaluate(i);
                t.localScale = new Vector3(scale, scale, scale);
                yield return null;
            }

            var finalScale = pulseInCurve.Evaluate(0);
            t.localScale = new Vector3(finalScale, finalScale, finalScale);
            _runningAnimations--;
        }
    }
}