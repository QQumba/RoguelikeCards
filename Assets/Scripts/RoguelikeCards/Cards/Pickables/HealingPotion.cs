using RoguelikeCards.Commands;
using UnityEngine;

namespace RoguelikeCards.Cards.Pickables
{
    public class HealingPotion : Pickable
    {
        [SerializeField] private int healPower;

        protected override void OnPickedUp()
        {
            var command = new ApplyHealingCommand(healPower, Targets.Hero);
            Card.Dispatcher.Dispatch(command);
        }
    }
}