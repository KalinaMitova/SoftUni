namespace _01_ClassBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box newBox = new Box(length, width, height);
            
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            Console.WriteLine($"Surface Area - {newBox.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {newBox.Volume():F2}");
        }
    }
}
