using System;
using System.Linq;

public class AddCommand : Command, ICommand, IExecutable
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IGemFactory gemFactory;

    public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory)
        : base(data)
    {
        this.Repository = repository;
        this.GemFactory = gemFactory;
    }
    
    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }
    
    public IGemFactory GemFactory
    {
        get { return gemFactory; }
        set { gemFactory = value; }
    }
    
    public override void Execute()
    {
        string weaponName = this.Data[0];

        IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if(weapon == null)
        {
            throw new ArgumentException("No weapon of that name!");
        }
                
        for (int i = 1; i < this.Data.Length; i+=2)
        {
            int index = int.Parse(this.Data[i]);
                        
            string[] gemArgs = this.Data[i + 1].Split(" ");

            IGem gem = this.GemFactory.CreateGem(gemArgs);

            weapon.AddGem(gem, index);            
        }
    }
}