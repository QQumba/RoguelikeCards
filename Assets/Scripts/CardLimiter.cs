using DefaultNamespace.Enemies;

namespace DefaultNamespace
{
    public class CardLimiter
    {
        private Game _game;
        

        public CardLimiter(Game game)
        {
            _game = game;
        }
        
        public Card LimitCard(Card card)
        {
            if (card is Enemy enemy)
            {
                if (enemy is KingKong kingKong && _game.TurnCount < 30)
                    return null;
                if(enemy is MonkFrog monkFrog && _game.TurnCount < 20)
                    return null;
                enemy.MaxHealth += _game.TurnCount / 10;
                enemy.Health = enemy.MaxHealth;
            }
            if (card is Weapon weapon)
            {
                if (weapon is BattleAxe battleAxe && _game.TurnCount < 30 || weapon is EpicSword epicSword && _game.TurnCount < 25)
                    return null;
                
                weapon.Damage += _game.TurnCount / 10;
            }
            

            return card;
        }
        
    }
}