using DefaultNamespace.Enemies;

namespace DefaultNamespace.Factories
{
    public class EnemyFactory : CardFactory
    {
        public GameState GameState;
        public Enemy[] Enemies;
        public int MaxEnemies = 4;

        private GenericCardFactory<Enemy> _factory;

        private void Start()
        {
            _factory = new GenericCardFactory<Enemy>(GameState, Enemies, MaxEnemies);
        }

        public override Card GetCard()
        {
            return _factory.GetCard();
        }
    }
}