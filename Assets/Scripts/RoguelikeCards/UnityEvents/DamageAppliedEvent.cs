using System;
using UnityEngine.Events;

namespace RoguelikeCards.UnityEvents
{
    [Serializable]
    public class DamageAppliedEvent : UnityEvent<int>
    {
    }
}