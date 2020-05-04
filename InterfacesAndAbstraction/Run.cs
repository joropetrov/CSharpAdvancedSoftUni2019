using System;
using InterfacesAndAbstractionClassWork.Shapes;

namespace InterfacesAndAbstractionClassWork
{
    class Run
    {

        static void Main(string[] args)
        {
            ConsoleColor BorderColor = ConsoleColor.Red;
            Console.ForegroundColor = BorderColor;

            IDrawable drawable2 = new Rectangle(10, 5);
            drawable2.Draw();

            IDrawable drawable = new Circle(15);
            drawable.Draw();
        }
    }
}
