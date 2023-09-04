using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            int[] denominations = { 10, 50, 100 };
            int[] amountsToPay = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            foreach (int amount in amountsToPay)
            {
                Console.WriteLine($"For {amount} EUR:");
                Console.WriteLine();
                CalculateCombinations(denominations, amount, new List<int>(), 0);
                Console.WriteLine();
            }
        }

        static void CalculateCombinations(int[] denominations, int remainingAmount, List<int> currentCombination, int index)
        {
            if (remainingAmount == 0)
            {
                PrintCombination(currentCombination);
                return;
            }

            if (remainingAmount < 0 || index >= denominations.Length)
                return;

            // Include the current denomination in the combination
            currentCombination.Add(denominations[index]);
            CalculateCombinations(denominations, remainingAmount - denominations[index], currentCombination, index);

            // Exclude the current denomination from the combination
            currentCombination.RemoveAt(currentCombination.Count - 1);
            CalculateCombinations(denominations, remainingAmount, currentCombination, index + 1);
        }

        static void PrintCombination(List<int> combination)
        {
            if (combination.Count > 0)
            {
                Console.Write("*  ");
                for (int i = 0; i < combination.Count; i++)
                {
                    int count = 1;
                    while (i < combination.Count - 1 && combination[i] == combination[i + 1])
                    {
                        count++;
                        i++;
                    }
                    Console.Write($"{count} x {combination[i]} EUR");
                    if (i < combination.Count - 1)
                    {
                        Console.Write(" + ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
