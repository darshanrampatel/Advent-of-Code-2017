using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day11
    {
        public static int Part1(string input)
        {
            var moves = input.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var startingPosition = new Vector3(0, 0, 0);
            var currentPosition = startingPosition;
            foreach (var move in moves)
            {
                var direction = Directions[move];
                currentPosition += direction;
            }
            return GetDistance(startingPosition, currentPosition);
        }

        private static Dictionary<string, Vector3> Directions
        {
            get => new Dictionary<string, Vector3>
                {
                    { "nw", new Vector3(+1, 0, -1) },//ne
                    { "n", new Vector3(+1, -1, 0) },//e
                    { "ne", new Vector3(0, -1, +1) },//se
                    { "se", new Vector3(-1, 0, +1) },//sw
                    { "s", new Vector3(-1, +1, 0) },//w
                    { "sw", new Vector3(0, +1, -1) }//nw
                };
        }

        private static int GetDistance(Vector3 startingPosition, Vector3 currentPosition)
        {
            var distance = (Math.Abs(startingPosition.X - currentPosition.X) + Math.Abs(startingPosition.Y - currentPosition.Y) + Math.Abs(startingPosition.Z - currentPosition.Z)) / 2;
            return (int)distance;
        }

        public static int Part2(string input)
        {
            var moves = input.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var startingPosition = new Vector3(0, 0, 0);
            var currentPosition = startingPosition;
            var maxDistance = 0;
            foreach (var move in moves)
            {
                var direction = Directions[move];
                currentPosition += direction;
                maxDistance = Math.Max(maxDistance, GetDistance(startingPosition, currentPosition));
            }
            return maxDistance;
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
