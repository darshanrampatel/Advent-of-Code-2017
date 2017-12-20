using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day14
    {
        public static int Part1(string input)
        {
            var rows = new HashSet<string>();
            for (int i = 0; i < 128; i++)
            {
                rows.Add($"{input}-{i}");
            }

            var count = 0;
            foreach (var row in rows)
            {
                var hash = Day10.Part2(row);
                var hex = HexStringToBinary(hash);
                count += hex.Count(c => c == '1');
            }

            return count;
        }

        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'a', "1010" },
            { 'b', "1011" },
            { 'c', "1100" },
            { 'd', "1101" },
            { 'e', "1110" },
            { 'f', "1111" }
        };

        public static string HexStringToBinary(string hex)
        {
            string result = string.Empty;
            foreach (char c in hex)
            {
                result += hexCharacterToBinary[char.ToLower(c)];
            }
            return result;
        }

        public static int Part2(string input)
        {
            var rows = new HashSet<string>();
            for (int i = 0; i < 128; i++)
            {
                rows.Add($"{input}-{i}");
            }
            var grid = new bool[128, 128];
            for (int i = 0; i < 128; i++)
            {
                var hash = Day10.Part2($"{input}-{i}");
                var hex = HexStringToBinary(hash);
                for (int j = 0; j < 128; j++)
                {
                    grid[i, j] = hex[j] == '1' ? true : false;

                }
            }
            int regions = 0;
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    if (grid[i, j])
                    {
                        regions++;
                        grid = ClearRegion(grid, i, j);
                    }

                }
            }
            return regions;
        }

        private static bool[,] ClearRegion(bool[,] grid, int i, int j)
        {
            if (grid[i, j])
            {
                grid[i, j] = false;
                var length = 128;
                if (j + 1 < length)
                {
                    grid = ClearRegion(grid, i, j + 1);
                }
                if (j > 0)
                {
                    grid = ClearRegion(grid, i, j - 1);
                }
                if (i + 1 < length)
                {
                    grid = ClearRegion(grid, i + 1, j);
                }
                if (i > 0)
                {
                    grid = ClearRegion(grid, i - 1, j);
                }
            }
            return grid;
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
