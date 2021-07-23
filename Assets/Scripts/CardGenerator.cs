using DefaultNamespace.CardStates;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private Card dummy;
        [SerializeField] private Game game;
        [SerializeField] private Card hero;

        public Card GenerateCard()
        {
            var card = dummy.GetInstance(game);
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