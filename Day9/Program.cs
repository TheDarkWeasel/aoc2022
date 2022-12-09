using System;
using System.Collections.Generic;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day9\\input.txt"))
            {
                string ln;

                //Set to 1 for solution of part one
                int knotCount = 9;

                Position headPos = new Position
                {
                    x = 0,
                    y = 0
                };

                List<Position> knots = new List<Position>();

                for (int i = 0; i < knotCount; i++)
                {
                    knots.Add(new Position
                    {
                        x = 0,
                        y = 0
                    });
                }

                List<Position> visitedPositions = new List<Position>();
                visitedPositions.Add(knots[knotCount - 1]);

                while ((ln = file.ReadLine()) != null)
                {
                    string[] commandParts = ln.Split(' ');
                    char direction = commandParts[0][0];
                    int count = int.Parse(commandParts[1]);

                    for (int i = 0; i < count; i++)
                    {
                        headPos = MoveHead(headPos, direction);

                        for (int j = 0; j < knotCount; j++)
                        {
                            Position previousKnot;
                            if (j == 0)
                            {
                                previousKnot = headPos;
                            }
                            else
                            {
                                previousKnot = knots[j - 1];
                            }
                            knots[j] = MoveTail(knots[j], previousKnot);

                            if (j == knotCount - 1 && !visitedPositions.Contains(knots[j]))
                            {
                                visitedPositions.Add(knots[j]);
                            }
                        }

                    }
                }

                Console.WriteLine("Solution Part 2: " + visitedPositions.Count);
            }
        }

        static Position MoveHead(Position oldPosition, char direction)
        {
            if (direction == 'R')
            {
                oldPosition.x++;
            }
            else if (direction == 'D')
            {
                oldPosition.y--;
            }
            else if (direction == 'U')
            {
                oldPosition.y++;
            }
            else if (direction == 'L')
            {
                oldPosition.x--;
            }

            return oldPosition;
        }

        static Position MoveTail(Position tailPosition, Position headPosition)
        {
            if (!DoesTailMove(tailPosition, headPosition))
            {
                return tailPosition;
            }

            if (tailPosition.y == headPosition.y)
            {
                if (tailPosition.x < headPosition.x)
                {
                    tailPosition.x = headPosition.x - 1;
                }
                else
                {
                    tailPosition.x = headPosition.x + 1;
                }

                return tailPosition;
            }

            if (tailPosition.x == headPosition.x)
            {
                if (tailPosition.y < headPosition.y)
                {
                    tailPosition.y = headPosition.y - 1;
                }
                else
                {
                    tailPosition.y = headPosition.y + 1;
                }

                return tailPosition;
            }

            //Diagonal case

            if (tailPosition.x < headPosition.x)
            {
                tailPosition.x++;
            }
            else
            {
                tailPosition.x--;
            }
            if (tailPosition.y < headPosition.y)
            {
                tailPosition.y++;
            }
            else
            {
                tailPosition.y--;
            }


            return tailPosition;
        }

        static bool DoesTailMove(Position tailPos, Position headPos)
        {
            return Math.Abs(tailPos.x - headPos.x) > 1 || Math.Abs(tailPos.y - headPos.y) > 1;
        }
    }

    struct Position
    {
        public int x;
        public int y;

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Position)obj).x == x && ((Position)obj).y == y;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return x + (y * 10000);
        }
    }
}
