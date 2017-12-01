using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day1
    {
        public static int Part1(string input)
        {
            var matchingDigits = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int next = i + 1;
                if (next == input.Length)
                {
                    next = 0;
                }
                if (input[i] == input[next])
                {
                    matchingDigits.Add(Int32.Parse(input[i].ToString()));
                }
            }

            var output = matchingDigits.Sum(d => d);
            return output;
        }

        public static int Part2(string input)
        {
            var matchingDigits = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int next = i + (input.Length / 2);
                if (next >= input.Length)
                {
                    next = next - input.Length;
                }
                if (input[i] == input[next])
                {
                    matchingDigits.Add(Int32.Parse(input[i].ToString()));
                }
            }

            var output = matchingDigits.Sum(d => d);
            return output;
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
