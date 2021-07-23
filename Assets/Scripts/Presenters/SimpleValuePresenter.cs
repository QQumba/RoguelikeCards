using TMPro;
using UnityEngine;

namespace DefaultNamespace.Cards.Presenters
{
    public class SimpleValuePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void UpdateValue(int value)
        {
            text.text = value.ToString();
        }
    }
}