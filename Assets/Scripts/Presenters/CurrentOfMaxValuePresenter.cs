using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Cards.Presenters
{
    public class CurrentOfMaxValuePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void UpdateValue(int current, int max)
        {
            text.text = $"{current}/{max}";
        }
    }
}