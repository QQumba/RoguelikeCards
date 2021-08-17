using System;
using RoguelikeCards.Cards;
using UnityEngine.Events;

namespace RoguelikeCards.UnityEvents
{
    [Serializable]
    public class DamageAppliedEvent : UnityEvent<int, Card>
    {
    }
}