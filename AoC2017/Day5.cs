using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day5
    {
        public static int Part1(string input)
        {
            var steps = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToList();
            var currentLocation = 0;
            var numberOfSteps = 0;
            while (0 <= currentLocation && currentLocation < steps.Count)
            {
                var instruction = steps[currentLocation];
                steps[currentLocation]++;
                currentLocation += instruction;
                numberOfSteps++;
            }
            return numberOfSteps;
        }

        public static int Part2(string input)
        {
            var steps = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToList();
            var currentLocation = 0;
            var numberOfSteps = 0;
            while (0 <= currentLocation && currentLocation < steps.Count)
            {
                var instruction = steps[currentLocation];
                if (instruction >= 3)
                {
                    steps[currentLocation]--;
                }
                else
                {
                    steps[currentLocation]++;
                }
                currentLocation += instruction;
                numberOfSteps++;
            }
            return numberOfSteps;
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
