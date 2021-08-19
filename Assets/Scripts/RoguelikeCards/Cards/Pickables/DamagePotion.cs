using System.Linq;
using UnityEngine;

namespace RoguelikeCards.Cards.Pickables
{
    public class DamagePotion : Pickable
    {
        protected override void OnPickedUp()
        {
            var enemies= Card.Navigator.GetCardComponents<IEnemy>();
            if (enemies.Count == 0)
            {
                return;
            }
            var enemy = enemies[Random.Range(0, enemies.Count)];
            enemy.Die();
        }
    }
}