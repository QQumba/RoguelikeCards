using System;

namespace RoguelikeCards.Commands
{
    [Flags]
    public enum Targets
    {
        Hero = 1,
        Adjacent = 2,
    }
}