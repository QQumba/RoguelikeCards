using System;
using UnityEngine.Events;

namespace RoguelikeCards.UnityEvents
{
    [Serializable]
    public class HealthChangedEvent : UnityEvent<int, int>
    {
    }
}