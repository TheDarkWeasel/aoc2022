using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Elf> elves = new List<Elf>();

            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day1\\input.txt"))
            {
                int elfCounter = 0;
                Elf current = new Elf();
                current.id = elfCounter;
                current.calories = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if(ln.Trim() != "")
                    {
                        current.calories += int.Parse(ln.Trim());
                    } else
                    {
                        elves.Add(current);
                        elfCounter++;
                        current = new Elf();
                        current.id = elfCounter;
                        current.calories = 0;
                    }
                }
                file.Close();
            }

            elves.Sort((a, b) => b.calories.CompareTo(a.calories));
            Console.WriteLine("Top 1: " + elves[0].calories);

            int topThree = elves[0].calories + elves[1].calories + elves[2].calories;
            Console.WriteLine("Top 3: " + topThree);
        }
    }

    struct Elf
    {
        public int id;
        public int calories;
    }
}
