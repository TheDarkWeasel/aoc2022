using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day3\\input.txt"))
            {
                string ln;

                int sumPartOne = 0;
                int sumPartTwo = 0;

                List<char[]> elves = new List<char[]>();

                while ((ln = file.ReadLine()) != null)
                {
                    sumPartOne = CalculatePartOne(ln, sumPartOne);
                    sumPartTwo = CalculatePartTwo(ln, sumPartTwo, elves);
                }

                Console.WriteLine("Sum Part One: " + sumPartOne);
                Console.WriteLine("Sum Part Two: " + sumPartTwo);

                file.Close();
            }
        }

        private static int CalculatePartTwo(string ln, int sumPartTwo, List<char[]> elves)
        {
            elves.Add(ln.Trim().ToCharArray());

            if (elves.Count == 3)
            {
                char duplicateEntry = '.';

                foreach (char entry in elves[0])
                {
                    if (Array.IndexOf(elves[1], entry) != -1 && Array.IndexOf(elves[2], entry) != -1)
                    {
                        duplicateEntry = entry;
                        break;
                    }
                }

                if (duplicateEntry == '.')
                {
                    throw new Exception("No duplicate!");
                }

                sumPartTwo += GetValueOfEntry(duplicateEntry);

                elves.Clear();
            }

            return sumPartTwo;
        }

        private static int CalculatePartOne(string ln, int sumPartOne)
        {
            char[] compartmentOne = ln.Substring(0, ln.Length / 2).ToCharArray();
            char[] compartmentTwo = ln.Substring(ln.Length / 2, ln.Length / 2).ToCharArray();

            char duplicateEntry = '.';

            foreach (char entry in compartmentOne)
            {
                if (Array.IndexOf(compartmentTwo, entry) != -1)
                {
                    duplicateEntry = entry;
                    break;
                }
            }

            if (duplicateEntry == '.')
            {
                throw new Exception("No duplicate!");
            }

            sumPartOne += GetValueOfEntry(duplicateEntry);
            return sumPartOne;
        }

        private static int GetValueOfEntry(char entry)
        {
            if (entry >= 'a' && entry <= 'z')
            {
                return entry - 96;
            }
            else
            {
                return entry - 38;
            }

        }
    }
}
