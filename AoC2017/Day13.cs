using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC2017
{
    public static class Day13
    {
        public static int Part1(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var layers = new HashSet<Layer>();
            foreach (var line in lines)
            {
                var splits = line.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

                layers.Add(new Layer
                {
                    ID = Int32.Parse(splits[0]),
                    Range = Int32.Parse(splits[1])
                });
            }
            var maxLayer = layers.Max(l => l.ID);
            var tripSeverity = 0;
            foreach (var layer in layers)
            {
                var period = 2 * (layer.Range - 1);
                var caught = layer.ID % period == 0;
                if (caught)
                {
                    tripSeverity += layer.Severity;
                }
            }
            return tripSeverity;
        }

        private class Layer
        {
            public int ID { get; set; }
            public int Range { get; set; }
            public int Severity => ID * Range;
        }

        public static int Part2(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var layers = new HashSet<Layer>();
            foreach (var line in lines)
            {
                var splits = line.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

                layers.Add(new Layer
                {
                    ID = Int32.Parse(splits[0]),
                    Range = Int32.Parse(splits[1])
                });
            }
            var maxLayer = layers.Max(l => l.ID);
            var delay = 0;
            bool successfulTrip = false;

            while (!successfulTrip)
            {
                bool hasBeenCaught = false;
                foreach (var layer in layers)
                {
                    var period = 2 * (layer.Range - 1);
                    var caught = (layer.ID + delay) % period == 0;
                    if (caught)
                    {
                        hasBeenCaught = true;
                        break;
                    }
                }

                if (!hasBeenCaught)
                {
                    successfulTrip = true;
                    break;
                }
                else
                {
                    delay++;
                }
            }

            return delay;
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
