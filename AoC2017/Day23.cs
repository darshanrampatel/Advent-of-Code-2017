using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day23
    {
        public static int Part1(string input)
        {
            var instructions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var registers = new Dictionary<string, long>
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 },
                { "e", 0 },
                { "f", 0 },
                { "g", 0 },
                { "h", 0 }
            };
            int mulCount = 0;
            int its = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                its++;
                if (its % 1000000 == 0)
                {
                    Console.WriteLine(its);
                }
                var instruction = instructions[i];
                var splits = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = splits[0];
                var registerToModify = splits[1];

                long v = 0;
                if (splits.Count > 2)
                {
                    var value = splits[2];
                    if (long.TryParse(value, out long result))
                    {
                        v = result;
                    }
                    else
                    {
                        v = registers[value];
                    }
                }
                switch (command)
                {
                    case "set":
                        registers[registerToModify] = v;
                        break;
                    case "sub":
                        registers[registerToModify] -= v;
                        break;
                    case "mul":
                        registers[registerToModify] *= v;
                        mulCount++;
                        break;
                    case "jnz":
                        if ((int.TryParse(registerToModify, out int test) && test != 0) || registers[registerToModify] != 0)
                        {
                            i = i + (int)v;
                            i--;
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return mulCount;
        }

        public static int Part2(string input)
        {
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
