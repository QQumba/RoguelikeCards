using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class TurnCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _TurnCount;
        public GameState _gameState;
        private void Update()
        {
            _TurnCount.text = $"{_gameState.TurnCount}";
            
        }
    }
}