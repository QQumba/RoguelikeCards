using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class GenericCardFactory<TCard> where TCard : Card
    {
        private readonly GameState _gameState;
        private readonly TCard[] _cards;

        private readonly int _maxCards;

        public GenericCardFactory(GameState gameState, TCard[] cards, int maxCards)
        {
            Debug.Log($"GenericCarFactory of type {typeof(TCard)}");
            _gameState = gameState;
            _cards = cards;
            _maxCards = maxCards;
        }

        public Card GetCard()
        {
            var chance = Random.value * 100;
            
            if (_gameState.GetCards<TCard>().Count < _maxCards)
            {
                return GetCardOrNull(chance, 40);
            }
            return GetCardOrNull(chance, 5);
        }

        // 0 ... 100  chance < 40
        private Card GetCardOrNull(float chance, float requiredChance)
        {
            if (chance < requiredChance)
            {
                return _cards[Random.Range(0, _cards.Length)];
            }

            return null;
        }
    }
}