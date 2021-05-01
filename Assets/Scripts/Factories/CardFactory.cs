using System;
using System.Collections.Generic;
using DefaultNamespace.Powerups;
using NUnit.Framework;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly List<ICardFactory> _factories = new List<ICardFactory>();
        
        private bool _cardGenerated = false;

        public void AddFactory(ICardFactory factory)
        {
            _factories.Add(factory);
        }
        
        public Card GetCard()
        {
            // Debug.Log("CardFactory:GetCard");
            Card card = null;
            var maxAttempts = 10;
            for (int i = 0; i < maxAttempts; i++)
            {
                foreach (var factory in _factories)
                {
                    if (!_cardGenerated)
                    {
                        card = factory.GetCard();
                        if (card != null)
                        {
                            _cardGenerated = true;
                        }
                    }
                }

                if (_cardGenerated)
                {
                    _cardGenerated = false;
                    break;
                }
            }

            return card;
        }
    }
}