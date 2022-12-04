using System;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day4\\input.txt"))
            {
                string ln;

                int inclusions = 0;
                int overlaps = 0;

                while ((ln = file.ReadLine()) != null)
                {
                    string[] assignments = ln.Split(',');

                    string assignmentElfOne = assignments[0];
                    string assignmentElfTwo = assignments[1];

                    if (CheckInclusion(assignmentElfOne, assignmentElfTwo))
                    {
                        inclusions++;
                    }

                    if (CheckOverlap(assignmentElfOne, assignmentElfTwo))
                    {
                        overlaps++;
                    }
                }

                Console.WriteLine("Inclusions: " + inclusions);
                Console.WriteLine("Overlaps: " + overlaps);

                file.Close();
            }
        }

        private static bool CheckInclusion(string one, string two)
        {
            string[] rangeOne = one.Split('-');
            string[] rangeTwo = two.Split('-');

            if (int.Parse(rangeOne[0]) <= int.Parse(rangeTwo[0]) && int.Parse(rangeOne[1]) >= int.Parse(rangeTwo[1])
                || int.Parse(rangeTwo[0]) <= int.Parse(rangeOne[0]) && int.Parse(rangeTwo[1]) >= int.Parse(rangeOne[1]))
            {
                return true;
            }

            return false;
        }

        private static bool CheckOverlap(string one, string two)
        {
            string[] rangeOne = one.Split('-');
            string[] rangeTwo = two.Split('-');

            if (int.Parse(rangeOne[0]) <= int.Parse(rangeTwo[1]) && int.Parse(rangeOne[1]) >= int.Parse(rangeTwo[0])
                || int.Parse(rangeTwo[0]) <= int.Parse(rangeOne[1]) && int.Parse(rangeTwo[1]) >= int.Parse(rangeOne[0]))
            {
                return true;
            }

            return false;
        }
    }
}
