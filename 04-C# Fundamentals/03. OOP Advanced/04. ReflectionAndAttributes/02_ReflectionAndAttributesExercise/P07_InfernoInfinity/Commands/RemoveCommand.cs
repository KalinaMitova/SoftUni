using System;
using System.Linq;

public class RemoveCommand : Command, ICommand, IExecutable
{
    [Inject]
    private IRepository repository;

    public RemoveCommand(string[] data, IRepository repository) 
        : base(data)
    {
        this.Repository = repository;
    }

    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        int socketIndex = int.Parse(this.Data[1]);

        IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            throw new ArgumentException("No weapon of that name!");
        }

        weapon.RemoveGem(socketIndex);
    }
}