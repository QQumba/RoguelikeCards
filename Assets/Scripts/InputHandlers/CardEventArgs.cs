using System;

namespace DefaultNamespace.Cards.InputHandlers
{
    public class CardEventArgs : EventArgs
    {
        public CardEventArgs(Card card)
        {
            Card = card;
        }

        public Card Card { get; }
    }
}