using System.Collections.Generic;

public interface IRepository : IAddable
{
    IReadOnlyCollection<IWeapon> Weapons { get; }
}