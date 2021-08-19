using UnityEngine;

namespace RoguelikeCards.Commands
{
    public static class TargetsExtensions
    {
        public static bool Is(this Targets targets, Targets target)
        {
            return (targets & target) == target;
        }
    }
}