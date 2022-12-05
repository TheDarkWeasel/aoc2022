using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day5\\input.txt"))
            {
                string ln;

                List<Stack> readStacks = new List<Stack>();
                List<Stack> stacksInCorrectOrderPartOne = new List<Stack>();
                List<Stack> stacksInCorrectOrderPartTwo = new List<Stack>();

                while ((ln = file.ReadLine()) != null)
                {
                    //Read stacks
                    if (ln.Contains('[') && ln.Contains(']'))
                    {
                        int stackNr = 0;
                        for (int i = 1; i < ln.Length; i += 4)
                        {
                            if (readStacks.Count <= stackNr)
                            {
                                readStacks.Add(new Stack());
                            }

                            if (ln[i] != ' ')
                            {
                                readStacks[stackNr].Push(ln[i]);
                            }

                            stackNr++;
                        }
                    }
                    else if (ln.StartsWith(" 1 "))
                    {
                        //Reverse stacks
                        foreach (Stack stack in readStacks)
                        {
                            Stack reverse = new Stack();
                            while (stack.Count > 0)
                            {
                                reverse.Push(stack.Pop());
                            }
                            stacksInCorrectOrderPartOne.Add(reverse);
                            stacksInCorrectOrderPartTwo.Add((Stack)reverse.Clone());
                        }
                    }
                    else if (ln.StartsWith("move"))
                    {
                        //Move stacks
                        string[] commandParts = ln.Split(' ');
                        int count = int.Parse(commandParts[1]);
                        int from = int.Parse(commandParts[3]);
                        int to = int.Parse(commandParts[5]);

                        Stack temp = new Stack();

                        for (int i = 0; i < count; i++)
                        {
                            stacksInCorrectOrderPartOne[to - 1].Push(stacksInCorrectOrderPartOne[from - 1].Pop());
                            temp.Push(stacksInCorrectOrderPartTwo[from - 1].Pop());
                        }

                        //Not efficient but works ;)
                        while (temp.Count != 0)
                        {
                            stacksInCorrectOrderPartTwo[to - 1].Push(temp.Pop());
                        }
                    }
                }

                file.Close();

                Console.WriteLine("Solution Part 1: ");
                foreach (Stack stack in stacksInCorrectOrderPartOne)
                {
                    Console.Write(stack.Peek());
                }

                Console.WriteLine("\nSolution Part 2: ");
                foreach (Stack stack in stacksInCorrectOrderPartTwo)
                {
                    Console.Write(stack.Peek());
                }
            }
        }
    }
}
