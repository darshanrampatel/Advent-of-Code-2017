using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day10
    {
        public static int Part1(string input, int listLength = 256)
        {
            var lengths = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(i => Int32.Parse(i)).ToList();
            var list = Enumerable.Range(0, listLength).ToList();
            var skipSize = 0;
            var currentPosition = 0;
            foreach (var length in lengths)
            {
                (list, skipSize, currentPosition) = ReverseInput(list, length, skipSize, currentPosition);
            }
            return list[0] * list[1];
        }

        public static (List<int> output, int skipSize, int currentPosition) ReverseInput(List<int> list, int length, int skipSize, int currentPosition)
        {
            var newList = new Dictionary<int, int>();
            var reversedList = new Dictionary<int, int>();
            var subList = new List<int>();
            var elements = length;
            var idx = currentPosition;
            while (elements > 0)
            {
                var modIndex = idx % list.Count;
                newList.Add(modIndex, list[modIndex]);
                subList.Add(list[modIndex]);
                elements--;
                idx++;
            }
            subList.Reverse();
            var j = 0;
            foreach (var e in newList)
            {
                reversedList.Add(e.Key, subList[j]);
                j++;
            }
            //var subList = list.Skip(currentPosition).Take(length).Reverse().Select((i, index) => new { index = index, value = i }).ToList().ToDictionary(t => t.index, t => t.value);
            for (int i = 0; i < list.Count; i++)
            {
                if (reversedList.ContainsKey(i))
                {
                    list[i] = reversedList[i];
                }
            }
            currentPosition += (length + skipSize);
            currentPosition %= list.Count;
            skipSize++;
            return (list, skipSize, currentPosition);
        }

        public static string Part2(string input, int listLength = 256)
        {
            var lengths = input.Select(c => (int)c).Concat(new List<int> { 17, 31, 73, 47, 23 }).ToList();
            var list = Enumerable.Range(0, listLength).ToList();
            var skipSize = 0;
            var currentPosition = 0;
            for (int i = 0; i < 64; i++)
            {
                foreach (var length in lengths)
                {
                    (list, skipSize, currentPosition) = ReverseInput(list, length, skipSize, currentPosition);
                }
            }
            var splitList = new List<List<int>>();
            for (int i = 0; i < list.Count; i += 16)
            {
                splitList.Add(list.GetRange(i, 16));
            }
            var denseHash = splitList.Select(l => l.Aggregate((x, y) => x ^ y)).Select(i => i.ToString("x2"));
            return string.Join("", denseHash);
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
