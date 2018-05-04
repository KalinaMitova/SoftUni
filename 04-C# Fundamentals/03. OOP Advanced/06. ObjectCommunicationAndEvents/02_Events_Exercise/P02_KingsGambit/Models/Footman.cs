namespace P02_KingsGambit
{
    using P02_KingsGambit.Contracts;
    using P02_KingsGambit.Models;
    using System;

    public class Footman : Subordinate
    {
        public Footman(string name)
            :base(name, "panicking", 2)
        {

        }
    }
}
