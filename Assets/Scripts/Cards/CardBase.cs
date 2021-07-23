using DefaultNamespace.Cards.Heroes;
using DefaultNamespace.CardStates;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public abstract class CardBase : MonoBehaviour
    {
        protected Game Game { get; set; }
        public CardState State { get; protected set; }

        public virtual void TurnUpdate() { }
    }
}