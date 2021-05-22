using System;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace.Enemies;
using DefaultNamespace.Factories;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class CardGenerator : MonoBehaviour
    {
        public CardFactory[] Factories;
        
        private void Start()
        {
            Debug.Log("CardGenerator initialized");
        }

        public Card GenerateCard()
        {
            var maxAttempts = 100;
            for (int i = 0; i < maxAttempts; i++)
            {
                foreach (var factory in Factories)
                {
                    var card = factory.GetCard();
                    if (card != null)
                    {
                        var instantiatedCard = Instantiate(card, Vector3.zero, Quaternion.identity);
                        return instantiatedCard;
                    }
                }
            }
            Debug.Log("CardGenerator.GenerateCard -> card generating failed.");
            return null;
        }
    }
}