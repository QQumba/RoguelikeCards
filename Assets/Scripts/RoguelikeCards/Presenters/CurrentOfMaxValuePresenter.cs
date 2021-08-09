using TMPro;
using UnityEngine;

namespace RoguelikeCards.Presenters
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