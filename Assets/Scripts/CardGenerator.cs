using System.Collections.Generic;
using DefaultNamespace.Factories;
using UnityEngine;

namespace DefaultNamespace
{
    public class CardGenerator : MonoBehaviour
    {
        public GameState GameState;
        public CardFactory[] Factories;    
        
        
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