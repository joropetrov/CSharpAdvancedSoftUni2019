using System;

namespace InterfacesAndAbstractionClassWork.Shapes
{
    class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; }
        public int Height { get; }

        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));

            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine("*" + new string (' ', this.Width - 2) + "*");
            }
            Console.WriteLine(new string('*', this.Width));

        }
    }
}
