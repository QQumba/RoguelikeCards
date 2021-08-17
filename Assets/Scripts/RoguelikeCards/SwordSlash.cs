using System;
using System.Collections;
using RoguelikeCards.Cards;
using RoguelikeCards.UnityEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoguelikeCards
{
    [RequireComponent(typeof(TrailRenderer))]
    public class SwordSlash : MonoBehaviour
    {
        [SerializeField] private SfxPlayer sfxPlayer;
        [SerializeField] private int animationSpeedMultiplier = 1;
        [SerializeField] private AnimationCurve trajectoryDeviation;
        [SerializeField] private DamageAppliedEvent damageAppliedEvent;

        private TrailRenderer _trail;
        private Transform _transform;
        private Vector3 _start;
        private Vector3 _end;

        private void Awake()
        {
            _trail = GetComponent<TrailRenderer>();
            _transform = GetComponent<Transform>();
        }

        public void Play(Card card)
        {
            var position = card.transform.position;
            _start = (Vector3) (Random.insideUnitCircle.normalized / 2) + position;
            _end = position - (_start - position);
            _transform.position = _start;
            _trail.Clear();

            sfxPlayer.Play();
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            damageAppliedEvent.Invoke(0, null);
            var normal = new Vector3(1, (_end - _start).x / (_end - _start).x);
            for (float i = 0; i <= 1; i += Time.deltaTime * animationSpeedMultiplier)
            {
                _transform.position =
                    Vector3.Lerp(_start, _end, i) + normal * trajectoryDeviation.Evaluate(i);
                yield return null;
            }
        }
    }
}