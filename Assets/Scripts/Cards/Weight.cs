using UnityEngine;

namespace DefaultNamespace.Cards
{
    public class Weight : MonoBehaviour
    {
        [SerializeField] private int value;

        public int Value => value;
    }
}