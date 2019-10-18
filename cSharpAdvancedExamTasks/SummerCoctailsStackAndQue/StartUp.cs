using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SummerCocktails.Retake13August
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ingredientsBasket = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse);

            var freshnessValues = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse);

            Dictionary<string, int> coctails = new Dictionary<string, int>();
            coctails.Add("Mimosa", 0);
            coctails.Add("Daiquiri", 0);
            coctails.Add("Sunshine", 0);
            coctails.Add("Mojito", 0);

            Queue<int> ingredients = new Queue<int>();
            Stack<int> freshnessLevel = new Stack<int>();

            FillIngredient(ingredientsBasket, ingredients);
            FillFreshnessLevel(freshnessValues, freshnessLevel);

            while (true)
            {
               
                if (ingredients.Count != 0 && freshnessLevel.Count != 0)
                {
                    if (ingredients.Peek() == 0)
                    {
                        ingredients.Dequeue();
                        continue;
                    }

                    int coctailCreationSum = ingredients.Peek() * freshnessLevel.Peek();

                    switch (coctailCreationSum)
                    {
                        case 150:
                            ingredients.Dequeue();
                            freshnessLevel.Pop();
                            coctails["Mimosa"]++;
                            break;

                        case 250:
                            ingredients.Dequeue();
                            freshnessLevel.Pop();
                            coctails["Daiquiri"]++;
                            break;

                        case 300:
                            ingredients.Dequeue();
                            freshnessLevel.Pop();
                            coctails["Sunshine"]++;
                            break;

                        case 400:
                            ingredients.Dequeue();
                            freshnessLevel.Pop();
                            coctails["Mojito"]++;
                            break;

                        default:
                            freshnessLevel.Pop();
                            var tempDigit = ingredients.Dequeue() + 5;
                            ingredients.Enqueue(tempDigit);
                            break;
                    }
                }
                else
                {
                    bool partyTime = coctails["Mimosa"] > 0 && coctails["Daiquiri"] > 0 && coctails["Sunshine"] > 0 && coctails["Mojito"] > 0;
                    if (partyTime) 
                    {
                        var result = coctails.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                        Console.WriteLine("It's party time! The cocktails are ready!");
                        
                        if (ingredients.Count != 0)
                        {
                            Console.WriteLine($"Ingredients left: {ingredients.Sum()}");

                        }
                        
                        foreach (var item in result)
                        {
                            Console.WriteLine($" # {item.Key} --> {item.Value}");
                            
                        }

                        break;
                    }

                    else
                    {
                        Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                        
                        if (ingredients.Count != 0)
                        {
                            Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                            
                        }
                        var endResult = coctails.Where(x => x.Value > 0).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                        foreach (var item in endResult)
                        {
                            Console.WriteLine($" # {item.Key} --> {item.Value}");
                            
                        }
                        break;
                    }
                }
            }
        }

        static void FillFreshnessLevel(IEnumerable<int> command, Stack<int> stack)
        {
            foreach (var item in command)
            {
                stack.Push(item);
            }
        }
        static void FillIngredient(IEnumerable<int> command, Queue<int> que)
        {
            foreach (var item in command)
            {
                que.Enqueue(item);
            }
        }
    }
}
