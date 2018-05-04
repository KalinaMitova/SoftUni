namespace P02_KingsGambit
{
    using System;
    
    using P02_KingsGambit.Models;

    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name)
            : base(name, "defending", 3)
        { }

        public override void ReactToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}
