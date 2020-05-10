using System;
using System.Collections.Generic;
using System.Linq;

namespace SugarHigh
{
    class Program
    {
        static void Main(string[] args)
        {
            var candys = Console.ReadLine().Split(", ")
                .Select(x => int.Parse(x))
                .ToArray();

            var threshold = int.Parse(Console.ReadLine());
            var sortedCandys = SortCandys(candys);

            Queue<int> eatenSugarCandys = new Queue<int>();
            eatenSugarCandys = CandysIcanEat(sortedCandys, threshold);

            var candysResulIndexes = FindResultIndexes(eatenSugarCandys, candys);

            var endResult = SortCandys(candysResulIndexes);

            Console.WriteLine($"sugarHigh(candies, threshold) = [{string.Join(", ", endResult)}].");
        }
        private static int[] FindResultIndexes(Queue<int> candysCanEat, int[] candys)
        {
            int candysCanEatLenght = candysCanEat.Count;
            int[] result = new int[candysCanEatLenght];

            for (int i = 0; i < candysCanEatLenght; i++)
            {
                int num = candysCanEat.Dequeue();
                for (int j = 0; j < candys.Length; j++)
                {
                    if (num == candys[j] && (CheckIfIndexDuplicates(result, j)))
                    {
                        result[i] = j;
                        break;
                    }
                }
            }
            return result;
        }
        private static bool CheckIfIndexDuplicates(int[] result, int j)
        {
            bool checkFlag = true;
            for (int i = 0; i < result.Length - 1; i++)
            {
                if (j == result[i])
                {
                    return checkFlag = false; ;
                }
            }
            return checkFlag;
        }
        private static Queue<int> CandysIcanEat(int[] candies, int tresholdValue)
        {
            var candysCanEat = new Queue<int>();

            var tempsum = 0;
            for (int i = 0; i <= candies.Length-1; i++)
            {
                int currentCandy = candies[i];
                if (tempsum + currentCandy <= tresholdValue)
                {
                    tempsum += currentCandy;
                    candysCanEat.Enqueue(currentCandy);
                }
            }
            return candysCanEat;
        }
        private static int[] SortCandys(int[] a)
        {
            var sortedCandies = new int[a.Length];
            Array.Copy(a,  sortedCandies,  a.Length);
            for (int i = 0; i < sortedCandies.Length - 1; i++)
            {
                for (int j = 0; j < sortedCandies.Length - 1; j++)
                {
                    if (sortedCandies[j] > sortedCandies[j + 1])
                    {
                        int temp = sortedCandies[j];
                        sortedCandies[j] = sortedCandies[j + 1];
                        sortedCandies[j + 1] = temp;
                    }
                }
            }
            return sortedCandies;
        }
    }
}
