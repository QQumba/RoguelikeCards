using RoguelikeCards.Cards;
using RoguelikeCards.Heroes;
using UnityEngine;

namespace RoguelikeCards
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private Card[] dummies;
        [SerializeField] private Game game;
        [SerializeField] private Card hero;

        public Card GenerateCard()
        {
            var card = dummies[Random.Range(0, dummies.Length)].GetInstance(game);
            return card;
        }

        public Card GenerateHero()
        {
            var heroInstance = hero.GetInstance(game);
            game.Hero = heroInstance as Hero;
            return heroInstance;
        }
    }
}