using UnityEngine;

namespace RoguelikeCards.Cards
{
    public class Weight : MonoBehaviour
    {
        [SerializeField] private int value;

        public int Value => value;
    }
}