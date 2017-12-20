using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day15
    {
        public static int Part1(string input)
        {
            var count = 0;
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var A = ulong.Parse(lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
            var B = ulong.Parse(lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

            for (int i = 0; i < 40000000; i++)
            {
                A = GenerateValue(A, true);
                B = GenerateValue(B, false);
                if ((A & 0xFFFF) == (B & 0xFFFF))
                {
                    count++;
                }
            }

            return count;
        }

        private const ulong A_FACTOR = 16807;
        private const ulong B_FACTOR = 48271;
        private const ulong DIVISOR = 2147483647;

        private static ulong GenerateValue(ulong startingValue, bool IsA)
        {
            return (startingValue * (IsA ? A_FACTOR : B_FACTOR)) % DIVISOR;
        }

        public static int Part2(string input)
        {
            var count = 0;
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var A = ulong.Parse(lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
            var B = ulong.Parse(lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

            for (int i = 0; i < 5000000; i++)
            {
                A = GenerateValuePart2(A, true);
                B = GenerateValuePart2(B, false);
                if ((A & 0xFFFF) == (B & 0xFFFF))
                {
                    count++;
                }
            }
            return count;
        }

        private const ulong A_MULTIPLES = 4;
        private const ulong B_MULTIPLES = 8;

        private static ulong GenerateValuePart2(ulong startingValue, bool IsA)
        {
            bool first = true;
            var newValue = startingValue;
            while (newValue % (IsA ? A_MULTIPLES : B_MULTIPLES) != 0 || first)
            {
                newValue = (newValue * (IsA ? A_FACTOR : B_FACTOR)) % DIVISOR;
                first = false;
            }
            return newValue;
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
