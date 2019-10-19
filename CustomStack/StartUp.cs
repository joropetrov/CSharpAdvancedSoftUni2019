using System;
using System.Diagnostics;
using System.Linq;

namespace CustomStack
{
   public class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
           
            stack.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(string.Join(" ", stack.Where(x => x % 2 == 0)));
        }
    }
}
