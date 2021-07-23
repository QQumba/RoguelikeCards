namespace DefaultNamespace.Cards
{
    public interface IDamageable
    {
        int Health { get; }
        int MaxHealth { get; }
        void ApplyDamage(uint damage);
        void Heal(uint value);
    }
}