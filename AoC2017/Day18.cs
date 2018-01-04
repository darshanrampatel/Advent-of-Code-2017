using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day18
    {
        public static int Part1(string input)
        {
            var instructions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            var registers = new Dictionary<string, long>();
            long? lastSound = null;

            for (int i = 0; i < instructions.Count; i++)
            {
                var instruction = instructions[i];
                var splits = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = splits[0];
                var registerToModify = splits[1];

                if (!registers.ContainsKey(registerToModify))
                {
                    registers.Add(registerToModify, 0);
                }

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
                        if (!registers.ContainsKey(value))
                        {
                            registers.Add(value, 0);
                        }
                        v = registers[value];
                    }
                }
                switch (command)
                {
                    case "snd":
                        lastSound = registers[registerToModify];
                        break;
                    case "set":
                        registers[registerToModify] = v;
                        break;
                    case "add":
                        registers[registerToModify] += v;
                        break;
                    case "mul":
                        registers[registerToModify] *= v;
                        break;
                    case "mod":
                        registers[registerToModify] %= v;
                        break;
                    case "rcv":
                        if (registers[registerToModify] != 0)
                        {
                            return (int)lastSound;
                        }
                        break;
                    case "jgz":
                        if (registers[registerToModify] > 0)
                        {
                            i = i + (int)v;
                            i--;
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return 0;
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
