using System;
using System.Linq;

public class PrintCommand : Command, ICommand, IExecutable
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWriter writer;

    public PrintCommand(string[] data, IRepository repository, IWriter writer) 
        : base(data)
    {
        this.Repository = repository;
        this.writer = writer;
    }

    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }
    
    public override void Execute()
    {
        string weaponName = this.Data[0];

        IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            throw new ArgumentException("No weapon of that name!");
        }
        
        int totalMinDamage = weapon.MinimumDamage + weapon.BonusMinimumDamage;
        int totalMaxDamage = weapon.MaximumDamage + weapon.BonusMaximumDamage;

        int totalStrength = weapon.Sockets.Sum(g => g != null ? g.Strength : 0);
        int totalAgility = weapon.Sockets.Sum(g => g != null ? g.Agility : 0);
        int totalVitality = weapon.Sockets.Sum(g => g != null ? g.Vitality : 0);

        string output = $"{weapon.Name}: {totalMinDamage}-{totalMaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";

        writer.WriteLine(output);
    }
}