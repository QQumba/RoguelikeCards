using DefaultNamespace.Powerups;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Factories
{
    public class PowerupFactory : CardFactory
    {
        public Powerup[] Powerups;
        

        public override Card GetCard()
        {
            return Powerups[Random.Range(0, Powerups.Length)];
        }
    }
}