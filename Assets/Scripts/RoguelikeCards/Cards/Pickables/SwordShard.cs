namespace RoguelikeCards.Cards.Pickables
{
    public class SwordShard : Pickable
    {
        protected override void OnPickedUp()
        {
            var hero = Card.Navigator.Hero;
            hero.Weapon.AddDamage(3);
        }
    }
}