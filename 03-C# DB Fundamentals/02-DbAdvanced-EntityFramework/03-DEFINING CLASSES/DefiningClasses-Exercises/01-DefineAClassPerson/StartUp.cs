using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineAClassPerson
{
    class StartUp
    {
        static void Main(string[] argBs)
        {
            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties
                (BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);
        }
    }
}
