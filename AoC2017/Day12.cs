using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC2017
{
    public static class Day12
    {
        public static int Part1(string input)
        {
            var list = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var entry in list)
            {
                var parts = entry.Split(" <-> ", StringSplitOptions.RemoveEmptyEntries);
                var mainDoor = Int32.Parse(parts[0]);
                var linkedDoors = parts[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(i => Int32.Parse(i)).ToList();
                if (!doors.ContainsKey(mainDoor))
                {
                    doors.Add(mainDoor, linkedDoors);
                }
            }
            var mainProgram = 0;
            return ProcessPrograms(mainProgram).Count;
        }

        private static Dictionary<int, List<int>> doors = new Dictionary<int, List<int>>();
        private static HashSet<int> linkedPrograms = new HashSet<int>();

        public static int Part2(string input)
        {
            var list = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var entry in list)
            {
                var parts = entry.Split(" <-> ", StringSplitOptions.RemoveEmptyEntries);
                var mainDoor = Int32.Parse(parts[0]);
                var linkedDoors = parts[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(i => Int32.Parse(i)).ToList();
                if (!doors.ContainsKey(mainDoor))
                {
                    doors.Add(mainDoor, linkedDoors);
                }
            }
            var mainProgram = 0;
            var groups = new List<HashSet<int>>();
            var idx = mainProgram;
            while (linkedPrograms.Count < doors.Count)
            {
                var tempList = ProcessPrograms(idx);
                foreach (var l in tempList)
                {
                    linkedPrograms.Add(l);
                }
                groups.Add(tempList);
                while (linkedPrograms.Contains(idx))
                {
                    idx++;
                }
            }
            return groups.Count;
        }

        private static HashSet<int> ProcessPrograms(int mainProgram)
        {
            var linked = new HashSet<int>();
            var count = doors.Count;
            while (count > 0)
            {
                foreach (var program in doors)
                {
                    if (program.Key == mainProgram)
                    {
                        linked.Add(program.Key);
                    }
                    else if (program.Value.Contains(mainProgram))
                    {
                        linked.Add(program.Key);
                    }
                    else
                    {
                        foreach (var i in program.Value)
                        {
                            if (linked.Contains(i))
                            {
                                linked.Add(program.Key);
                            }
                        }
                    }
                }
                count--;
            }
            return linked;
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
