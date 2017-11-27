using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Animals
{
    class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
            : base(name, age, gender)
        {
            base.Gender = "Female";
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
