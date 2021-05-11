using DefaultNamespace.Chests;

namespace DefaultNamespace.Factories
{
    public class ChestsFactory : CardFactory
    {
        public GameState GameState;
        public Chest[] Chests;
        public int MaxChests = 4;

        private GenericCardFactory<Chest> _factory;
        
        private void Awake()
        {
            _factory = new GenericCardFactory<Chest>(GameState, Chests, MaxChests);
        }

        public override Card GetCard()
        {
            return _factory.GetCard();
        }
    }
}