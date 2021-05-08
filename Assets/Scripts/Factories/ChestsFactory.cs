using System;
using DefaultNamespace.Chests;

namespace DefaultNamespace.Factories
{
    public class ChestsFactory : CardFactory
    {
        public override Card GetCard()
        {
            throw new Exception();
        }
    }
}