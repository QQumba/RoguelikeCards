using System;

namespace RoguelikeCards.RCEventArgs
{
    public class HealingAppliedEventArgs : EventArgs
    {
        public HealingAppliedEventArgs(int heal)
        {
            Heal = heal;
        }

        public int Heal { get; }
    }
}