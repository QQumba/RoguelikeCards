using System;
using DefaultNamespace.Chests;

namespace DefaultNamespace.Factories
{
    public class ChestsFactory : ICardFactory
    {
        public Card GetCard()
        {
            throw new Exception();
        }
    }
}