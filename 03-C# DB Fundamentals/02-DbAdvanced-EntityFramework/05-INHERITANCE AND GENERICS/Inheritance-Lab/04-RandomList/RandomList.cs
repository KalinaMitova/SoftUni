using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RandomList
{
    class RandomList : List<string>
    {
        private Random rnd;

        public RandomList() : base()
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {
            var index = rnd.Next(0, this.Count);
            var element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
