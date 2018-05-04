public class CreateCommand : Command, ICommand, IExecutable
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IWeaponFactory weaponFactory;

    public CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory)
        : base(data)
    {
        this.Repository = repository;
        this.WeaponFactory = weaponFactory;
    }
  
    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }
    
    public IWeaponFactory WeaponFactory
    {
        get { return weaponFactory; }
        set { weaponFactory = value; }
    }


    public override void Execute()
    {
        IWeapon weapon = WeaponFactory.CreateWeapon(this.Data);
        this.Repository.Add(weapon);
    }
}