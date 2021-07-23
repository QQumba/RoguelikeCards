﻿using System;

namespace DefaultNamespace.Cards.Presenters
{
    public class CurrentOfMaxValueChangedEventArgs : EventArgs
    {
        public CurrentOfMaxValueChangedEventArgs(int current, int max)
        {
            Current = current;
            Max = max;
        }

        public int Current { get; }
        public int Max { get; }
    }
}