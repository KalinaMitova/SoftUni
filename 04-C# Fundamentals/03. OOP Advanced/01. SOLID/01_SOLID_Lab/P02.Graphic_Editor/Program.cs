using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var rect = new Rectangle();
            var circle = new Circle();
            var square = new Square();

            var ge = new GraphicEditor();

            ge.DrawShape(rect);
            ge.DrawShape(circle);
            ge.DrawShape(square);
        }
    }
}
