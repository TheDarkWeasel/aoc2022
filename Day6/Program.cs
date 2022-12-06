using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day6\\input.txt"))
            {
                string ln;

                FixedSizeQueue<char> startOfPacketBuffer = new FixedSizeQueue<char>
                {
                    Limit = 4
                };

                FixedSizeQueue<char> startOfMessageBuffer = new FixedSizeQueue<char>
                {
                    Limit = 14
                };

                bool partOneSolved = false;
                bool partTwoSolved = false;

                while ((ln = file.ReadLine()) != null)
                {
                    for (int i = 0; i < ln.Length; i++)
                    {
                        char current = ln[i];

                        startOfPacketBuffer.Enqueue(current);
                        startOfMessageBuffer.Enqueue(current);

                        if (startOfPacketBuffer.DistinctCount() == 4 && !partOneSolved)
                        {
                            Console.WriteLine("Solution Part 1: " + (i + 1));
                            partOneSolved = true;
                        }

                        if (startOfMessageBuffer.DistinctCount() == 14 && !partTwoSolved)
                        {
                            Console.WriteLine("Solution Part 2: " + (i + 1));
                            partTwoSolved = true;
                        }
                    }

                }
            }
        }
    }

    public class FixedSizeQueue<T>
    {
        Queue<T> q = new Queue<T>();

        public int Limit { get; set; }
        public bool Contains(T obj)
        {
            return q.Contains(obj);
        }

        public int DistinctCount()
        {
            return q.Distinct().Count();
        }
        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            T overflow;
            while (q.Count > Limit && q.TryDequeue(out overflow)) ;
        }
    }
}
