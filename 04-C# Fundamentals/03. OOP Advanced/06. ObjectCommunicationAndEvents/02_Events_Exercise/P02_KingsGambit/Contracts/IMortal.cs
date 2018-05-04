namespace P02_KingsGambit.Contracts
{
    public interface IMortal
    {
        bool IsAlive { get; }

        int HitPoints { get; }

        void TakeDamage();

        void Die();
    }
}
