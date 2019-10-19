using System;
using System.Diagnostics;
using System.Collections.Generic;
using CustomList;

namespace CustomList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new CustomList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Debug.Assert(list[2].Equals(2));
            Debug.Assert(list.Count == 10);
            list.RemoveAt(2);
            Debug.Assert(list[2] == 3);
            Debug.Assert(list[3] == 4);
            Debug.Assert(list.Count.Equals(9));
            list.Reverse();
            Debug.Assert(list.Count == 9);
            Debug.Assert(list[0] == 9);
            Debug.Assert(list[1] == 8);

            Console.WriteLine(list.ToString());
            
        }
    }
}
