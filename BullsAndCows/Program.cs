using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    internal class Program
    {
        private static List<int> numbers = new List<int>();
        private static Random rand = new Random();

        private static int generateNumber()
        {
            var index = rand.Next(numbers.Count);
            return numbers[index];
        }

        /// <summary>
        /// Generates all possible numbers
        /// </summary>
        private static void generateNumbers()
        {
            for (int a = 1; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    if (b == a) continue;
                    for (int c = 0; c < 10; c++)
                    {
                        if (c == a || c == b) continue;
                        for (int d = 0; d < 10; d++)
                        {
                            if (d == a || d == b || d == c) continue;
                            numbers.Add(a * 1000 + b * 100 + c * 10 + d);
                        }
                    }
                }
            }
        }

        private static bool hasSameBullsAndCows(string generatedNumber, string number, int bulls, int cows)
        {
            var bullsCount = 0;
            var cowsCount = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (generatedNumber[j] == number[i])
                    {
                        if (i == j) bullsCount++;
                        else cowsCount++;
                    }
                }
            }
            return bulls == bullsCount && cows == cowsCount;
        }

        private static void Main(string[] args)
        {
            generateNumbers();
            Console.WriteLine(5678);
            while (true)
            {
                var generatedNumber = generateNumber();
                Console.WriteLine(generatedNumber);
                var bullsAndCows = Console.ReadLine();
                if (bullsAndCows == "4,0")
                {
                    return;
                }
                var tempArray = bullsAndCows.Split(',');
                var bulls = Int32.Parse(tempArray[0]);
                var cows = Int32.Parse(tempArray[1]);
                List<int> toDelete = new List<int>();
                foreach (var number in numbers)
                {
                    if (!hasSameBullsAndCows(number.ToString(), generatedNumber.ToString(), bulls, cows))
                    {
                        toDelete.Add(number);
                    }
                }
                foreach (var toDel in toDelete)
                {
                    numbers.Remove(toDel);
                }
            }
        }
    }
}