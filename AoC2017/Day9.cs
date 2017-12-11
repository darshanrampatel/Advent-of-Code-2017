using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day9
    {
        public static int Part1(string input)
        {
            return CalculateNumberOfGroups(input).score;
        }

        public static (int groups, int score, int garbageRemoved) CalculateNumberOfGroups(string input)
        {
            var groups = 0;
            var score = 0;
            var location = 0;
            var garbageRemoved = 0;
            bool withinGroup = false;
            bool withinGarbage = false;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '{':
                        if (!withinGarbage)
                        {
                            withinGroup = true;
                            location++;
                        }
                        else
                        {
                            garbageRemoved++;
                        }
                        break;
                    case '}':
                        if (withinGroup && !withinGarbage)
                        {
                            groups++;
                            score += location;
                            location--;
                        }
                        else if (withinGarbage)
                        {
                            garbageRemoved++;
                        }
                        break;
                    case '<':
                        if (!withinGarbage)
                        {
                            withinGarbage = true;
                        }
                        else
                        {
                            garbageRemoved++;
                        }
                        break;
                    case '>':
                        if (withinGarbage)
                        {
                            withinGarbage = false;
                        }
                        break;
                    case '!':
                        if (withinGarbage)
                        {
                            i++;
                        }
                        break;
                    default:
                        if (withinGarbage)
                        {
                            garbageRemoved++;
                        }
                        break;
                }
            }
            return (groups, score, garbageRemoved);
        }

        public static int Part2(string input)
        {
            return CalculateNumberOfGroups(input).garbageRemoved;
        }

        public static void Run()
        {
            Console.WriteLine();
            var day = MethodBase.GetCurrentMethod().DeclaringType.Name;
            Console.WriteLine(day);
            try
            {
                var input = File.ReadAllText($"{day}.txt");
                Console.WriteLine($"{nameof(Part1)}: {Part1(input)}");
                Console.WriteLine($"{nameof(Part2)}: {Part2(input)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find input file!");
            }
        }
    }
}
