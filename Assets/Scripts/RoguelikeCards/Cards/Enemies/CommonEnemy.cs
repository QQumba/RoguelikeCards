using System;
using RoguelikeCards.Heroes;
using RoguelikeCards.RCEventArgs;
using UnityEngine;

namespace RoguelikeCards.Cards.Enemies
{
    public class CommonEnemy : Enemy
    {
        // do nothing on default
        protected override void OnDied() { }
    }
}