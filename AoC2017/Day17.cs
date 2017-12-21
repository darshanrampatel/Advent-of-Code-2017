using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day17
    {
        public static int Part1(string input)
        {
            var step = int.Parse(input);
            var currentPosition = 0;
            var buffer = new List<int>
            {
                0
            };
            for (int i = 1; i <= 2017; i++)
            {
                currentPosition = ((currentPosition + step) % buffer.Count) + 1;
                buffer.Insert(currentPosition, i);
            }
            return buffer.ElementAt(currentPosition + 1);
        }

        public static int Part2(string input)
        {
            var step = int.Parse(input);
            var result = 0;
            var currentPosition = 0;
            for (int i = 1; i <= 50000000; i++)
            {
                currentPosition = ((currentPosition + step) % i) + 1;
                if (currentPosition == 1)//i.e. the element after 0
                {
                    result =  i;
                }
            }
            return result;
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
