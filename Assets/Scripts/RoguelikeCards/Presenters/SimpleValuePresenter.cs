using TMPro;
using UnityEngine;

namespace RoguelikeCards.Presenters
{
    public class SimpleValuePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void UpdateValue(string value)
        {
            text.text = value;
        }
    }
}