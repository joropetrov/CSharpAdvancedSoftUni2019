using System;

namespace InterfacesAndAbstractionClassWork.Shapes
{
   public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; }
        public void Draw()
        {
            for (int row = 0; row <= this.Radius * 2; row++)
            {
                for (int col = 0; col <= this.Radius * 2; col++)
                {
                    var a = row - this.Radius;
                    var b = col - this.Radius;

                    var distance = Math.Ceiling(Math.Sqrt((a) * (a)
                        + (b) * (b)));

                    if (distance == this.Radius)
                    {
                        Console.Write("**");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
