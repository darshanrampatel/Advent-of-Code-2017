using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day16
    {
        public static string Part1(string input, int letters = 16)
        {
            var moves = input.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var programs = new string(Enumerable.Range('a', letters).Select(x => (char)x).ToArray());
            return Dance(programs, moves);
        }

        private static string PerformMove(string programs, string move)
        {
            var details = move.Substring(1);
            switch (move[0])
            {
                case 's':
                    var numberToMove = Int32.Parse(details);
                    var lastPart = programs.Substring(0, programs.Length - numberToMove);
                    var firstPart = programs.Substring(programs.Length - numberToMove);
                    programs = firstPart + lastPart;
                    break;
                case 'x':
                    var splitsX = details.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    var xA = Int32.Parse(splitsX[0]);
                    var xB = Int32.Parse(splitsX[1]);
                    var tempA = programs[xA];
                    var tempB = programs[xB];
                    programs = programs.Remove(xA, 1);
                    programs = programs.Insert(xA, tempB.ToString());
                    programs = programs.Remove(xB, 1);
                    programs = programs.Insert(xB, tempA.ToString());
                    break;
                case 'p':
                    var splitsP = details.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    var pA = splitsP[0];
                    var pB = splitsP[1];
                    var idxA = programs.IndexOf(pA);
                    var idxB = programs.IndexOf(pB);
                    programs = programs.Remove(idxA, 1);
                    programs = programs.Insert(idxA, pB);
                    programs = programs.Remove(idxB, 1);
                    programs = programs.Insert(idxB, pA);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return programs;
        }

        private static string Dance(string programs, List<string> moves)
        {
            foreach (var move in moves)
            {
                programs = PerformMove(programs, move);
            }
            return programs;
        }

        public static string Part2(string input, int letters = 16, int rounds = 1000000000)
        {
            var moves = input.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var programs = new string(Enumerable.Range('a', letters).Select(x => (char)x).ToArray());
            var starting = Dance(programs, moves);
            programs = starting;
            var extras = 0;
            for (int i = 0; i < rounds; i++)
            {
                programs = Dance(programs, moves);
                if (starting == programs)
                {
                    var cycle = i + 1;
                    extras = rounds % cycle;
                    extras--;
                    break;
                }
            }
            programs = starting;
            for (int i = 0; i < extras; i++)
            {
                programs = Dance(programs, moves);
            }
            Debug.WriteLine(programs);
            return programs;
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
