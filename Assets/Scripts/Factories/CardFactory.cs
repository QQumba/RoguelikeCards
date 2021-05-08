using UnityEngine;

namespace DefaultNamespace.Factories
{
    public abstract class CardFactory : MonoBehaviour
    {
        public abstract Card GetCard();
    }
}