using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day2
    {
        public static int Part1(string input)
        {
            var output = 0;
            var rows = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var diff = Part1RowDifference(row);
                output += diff;
            }

            return output;
        }

        public static int Part1RowDifference(string row)
        {
            var chars = row.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).Where(c => !c.Equals(" ")).Select(c => Int32.Parse(c));
            return chars.Max() - chars.Min();
        }

        public static int Part2(string input)
        {
            var output = 0;
            var rows = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var diff = Part2RowDifference(row);
                output += diff;
            }
            return output;
        }

        public static int Part2RowDifference(string row)
        {
            var chars = row.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).Where(c => !c.Equals(" ")).Select(c => Int32.Parse(c)).ToList();
            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = 0; j < chars.Count; j++)
                {
                    if (i != j)
                    {
                        if (chars[i] > chars[j])
                        {
                            if (chars[i] % chars[j] == 0)
                            {
                                return chars[i] / chars[j];
                            }
                        }
                        else
                        {
                            if (chars[j] % chars[i] == 0)
                            {
                                return chars[j] / chars[i];
                            }
                        }
                    }
                }
            }
            return 0;
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
