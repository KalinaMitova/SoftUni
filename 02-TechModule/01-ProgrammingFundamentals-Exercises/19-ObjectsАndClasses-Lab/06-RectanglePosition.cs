using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RectanglePosition
{
    class Program
    {
        class Rectangle
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int Bottom
            {
                get
                {
                    return Top + Height;
                }
            }

            public int Right
            {
                get
                {
                    return Left + Width;
                }
            }

            public bool IsInside(Rectangle other)
            {
                var isInside =
                    Left >= other.Left && 
                    Top >= other.Top &&
                    Bottom <= other.Bottom && 
                    Right <= other.Right;

                return isInside;
            }
        }
        static void Main(string[] args)
        {
            var rect1 = ReadRectangle();
            var rect2 = ReadRectangle();

            var isInside = rect1.IsInside(rect2);

            Console.WriteLine(isInside ? "Inside" : "Not inside");
        }

        private static Rectangle ReadRectangle()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var left = line[0];
            var top = line[1];
            var width = line[2];
            var height = line[3];

            return new Rectangle
            {
                Left = left,
                Top = top,
                Width = width,
                Height = height
            };
        }
    }
}
