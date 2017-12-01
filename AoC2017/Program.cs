using System;
using System.Reflection;

namespace AoC2017
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017");

            Console.WriteLine("Choose a day to run or press any other key to run all days");
            if (Int32.TryParse(Console.ReadLine(), out var day))
            {
                RunDay(day, true);
            }
            else
            {
                Console.WriteLine("Running all days");
                for (int i = 1; i <= 25; i++)
                {
                    RunDay(i);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();
        }

        static void RunDay(int day, bool showWarning = false)
        {
            var run = Type.GetType($"AoC2017.Day{day}")?.GetRuntimeMethod("Run", new Type[0]);
            if (run != null)
            {
                run.Invoke(null, null);
            }
            else if (showWarning)
            {
                Console.WriteLine($"Could not run Day{day}");
            }
        }
    }
}
