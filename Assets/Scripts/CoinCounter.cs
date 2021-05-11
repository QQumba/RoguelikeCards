using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _coinCount;
        [SerializeField] private Game _game;
        
        private void Update()
        {
            _coinCount.text = _game.CoinCount.ToString();
        }
    }
}