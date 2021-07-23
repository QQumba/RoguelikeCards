﻿using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class GameFieldInitializer : MonoBehaviour
    {
        [SerializeField] private CardGenerator generator;

        public void InitializeGameField(Card[] cards, int sideSize)
        {
            var heroIndex = Random.Range(0, cards.Length);

            for (int i = 0; i < cards.Length; i++)
            {
                var card = i == heroIndex ? generator.GenerateHero() : generator.GenerateCard();
                card.transform.position = new Vector3(i % sideSize, i / sideSize, 0);
                cards[i] = card;
            }
        }

        public void UpdateGameField(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == null)
                {
                    var card = generator.GenerateCard();
                    card.transform.position = new Vector3(i % (int) Mathf.Sqrt(cards.Length),
                        i / (int) Mathf.Sqrt(cards.Length), 0);
                    cards[i] = card;
                    card.UpdateState();
                }
            }
        }
    }
}