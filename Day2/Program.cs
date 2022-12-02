using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PartOneRound> partOneRounds = new List<PartOneRound>();
            List<PartTwoRound> partTwoRounds = new List<PartTwoRound>();

            using (StreamReader file = new StreamReader("E:\\repos\\aoc2022\\Day2\\input.txt"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    string[] parts = ln.Split(' ');
                    PartOneRound first = new PartOneRound
                    {
                        opponentType = parts[0],
                        playerType = parts[1]
                    };
                    partOneRounds.Add(first);
                    PartTwoRound second = new PartTwoRound
                    {
                        opponentType = parts[0],
                        outcomeType = parts[1]
                    };
                    partTwoRounds.Add(second);

                }
                file.Close();
            }

            //Part 1
            int partOneScore = 0;
            foreach (PartOneRound round in partOneRounds)
            {
                partOneScore += round.getOverallScore();
            }

            Console.WriteLine("Score Part 1: " + partOneScore);

            //Part 2
            int partTwoScore = 0;
            foreach (PartTwoRound round in partTwoRounds)
            {
                partTwoScore += round.getOverallScore();
            }

            Console.WriteLine("Score Part 2: " + partTwoScore);
        }
    }

    struct PartOneRound
    {
        public string opponentType;
        public string playerType;

        private int getTypeScore()
        {
            switch (playerType)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }

        private int getOutcomeScore()
        {
            if (playerType == "X" && opponentType == "A"
                || playerType == "Y" && opponentType == "B"
                || playerType == "Z" && opponentType == "C")
            {
                return 3;
            }
            else if (playerType == "X" && opponentType == "C"
              || playerType == "Y" && opponentType == "A"
              || playerType == "Z" && opponentType == "B")
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        public int getOverallScore()
        {
            return getTypeScore() + getOutcomeScore();
        }
    }

    struct PartTwoRound
    {
        public string opponentType;
        public string outcomeType;

        private int getTypeScore(string playerType)
        {
            switch (playerType)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }

        private int getOutcomeScore(string playerType)
        {
            if (playerType == "X" && opponentType == "A"
                || playerType == "Y" && opponentType == "B"
                || playerType == "Z" && opponentType == "C")
            {
                return 3;
            }
            else if (playerType == "X" && opponentType == "C"
              || playerType == "Y" && opponentType == "A"
              || playerType == "Z" && opponentType == "B")
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        private string calculatePlayerType()
        {
            if (outcomeType == "X")
            {
                //lose
                switch (opponentType)
                {
                    case "A":
                        return "Z";
                    case "B":
                        return "X";
                    case "C":
                        return "Y";
                }
            }
            else if (outcomeType == "Y")
            {
                //draw
                switch (opponentType)
                {
                    case "A":
                        return "X";
                    case "B":
                        return "Y";
                    case "C":
                        return "Z";
                }

            }
            else if (outcomeType == "Z")
            {
                //win
                switch (opponentType)
                {
                    case "A":
                        return "Y";
                    case "B":
                        return "Z";
                    case "C":
                        return "X";
                }
            }

            //if this happens, everything breaks
            return "";
        }

        public int getOverallScore()
        {
            string playerType = calculatePlayerType();
            return getTypeScore(playerType) + getOutcomeScore(playerType);
        }
    }
}
