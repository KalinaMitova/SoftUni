using System.Collections.Generic;

namespace P02_KingsGambit.Contracts
{
    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubordinate(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}
