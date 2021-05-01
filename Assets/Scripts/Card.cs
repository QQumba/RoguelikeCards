namespace DefaultNamespace
{
    public abstract class Card
    {
        protected readonly Hero Hero;

        protected Card(Hero hero)
        {
            Hero = hero;
        }
        
        public abstract bool TryEnter();
    }
}