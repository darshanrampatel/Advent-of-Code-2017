using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day6
    {
        public static int Part1(string input)
        {
            var banks = input.Split("\t", StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToList();
            var seenBanks = new List<List<int>>();
            var newBank = banks.ToList();
            while (!seenBanks.Any(i => i.SequenceEqual(newBank)))
            {
                seenBanks.Add(newBank);
                newBank = RedistributeMemory(newBank.ToList());
            }
            return seenBanks.Count;
        }

        private static List<int> RedistributeMemory(List<int> banks)

        {
            int max = banks.Max();
            var maxItem = banks.IndexOf(max);
            var nextItem = maxItem;
            var count = banks[maxItem];
            while (count > 0)
            {
                nextItem++;
                if (nextItem >= banks.Count)
                {
                    nextItem = nextItem - banks.Count;
                }
                banks[nextItem]++;
                banks[maxItem]--;
                count--;
            }
            return banks;
        }

        public static int Part2(string input)
        {
            var banks = input.Split("\t", StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToList();
            var seenBanks = new List<List<int>>();
            var newBank = banks.ToList();
            while (!seenBanks.Any(i => i.SequenceEqual(newBank)))
            {
                seenBanks.Add(newBank);
                newBank = RedistributeMemory(newBank.ToList());
            }
            var firstSeen = seenBanks.First(i => i.SequenceEqual(newBank));
            return seenBanks.Count - seenBanks.IndexOf(firstSeen);
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
