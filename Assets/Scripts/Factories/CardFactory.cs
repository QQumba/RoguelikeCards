using System.Collections.Generic;

namespace DefaultNamespace.Factories
{
    public class CardFactory
    {
        private readonly List<ICardFactory> _factories = new List<ICardFactory>();

        public CardFactory AddFactory(ICardFactory factory)
        {
            _factories.Add(factory);
            return this;
        }
        
        public Card GetCard(int maxAttempts = 100)
        {
            Card card = null;
            for (int i = 0; i < maxAttempts; i++)
            {
                foreach (var factory in _factories)
                {
                    card = factory.GetCard();
                    if (card != null)
                    {
                        return card;
                    }
                }
            }

            return card;
        }
    }
}