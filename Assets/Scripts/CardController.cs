using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class CardController
    {
        private GameField _gameField;

        public Vector3 GetCardPosition()
        {
            return Vector3.zero;
        }

        public CardController(GameField gameField)
        {
            _gameField = gameField;
        }

        public void Move(Card from, Card to)
        {
            
        }

        public void SwapWith(Card source, Card destination)
        {
            
        }

        public void Replace(Card source, Card destination)
        {
            
        }
    }
}