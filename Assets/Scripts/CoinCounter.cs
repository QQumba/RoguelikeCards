﻿using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _CoinCount;
        public GameState _gameState;
        private void Update()
        {
            _CoinCount.text = $"{_gameState.CoinCount}";
          
       
        }
    }
}