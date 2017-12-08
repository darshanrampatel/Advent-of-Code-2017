using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day8
    {
        public static int Part1(string input)
        {
            var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<string, int>();

            foreach (var instruction in instructions)
            {
                registers = ProcessInstruction(instruction, registers);
            }

            return registers.Max(r => r.Value);
        }

        private static Dictionary<string, int> ProcessInstruction(string instruction, Dictionary<string, int> registers)
        {
            var splits = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var registerToModifyName = splits[0];
            var increment = splits[1] == "inc" ? true : false;
            var amount = Int32.Parse(splits[2]);
            var amountToAdd = increment ? amount : -amount;
            var conditionRegisterName = splits[4];
            var conditionSymbol = splits[5];
            var conditionValue = Int32.Parse(splits[6]);

            if (!registers.ContainsKey(registerToModifyName))
            {
                registers.Add(registerToModifyName, 0);
            }

            if (!registers.ContainsKey(conditionRegisterName))
            {
                registers.Add(conditionRegisterName, 0);
            }

            if (Compare(registers[conditionRegisterName], conditionSymbol, conditionValue))
            {
                registers[registerToModifyName] += amountToAdd;
            }

            return registers;
        }

        private static bool Compare(int registerValue, string comparator, int conditionValue)
        {
            switch (comparator)
            {
                case ">":
                    return registerValue > conditionValue;
                case ">=":
                    return registerValue >= conditionValue;
                case "<":
                    return registerValue < conditionValue;
                case "<=":
                    return registerValue <= conditionValue;
                case "==":
                    return registerValue == conditionValue;
                case "!=":
                    return registerValue != conditionValue;
                default:
                    break;
            }
            return false;
        }

        public static int Part2(string input)
        {
            var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var registers = new Dictionary<string, int>();
            int maxValue = int.MinValue;

            foreach (var instruction in instructions)
            {
                registers = ProcessInstruction(instruction, registers);
                maxValue = Math.Max(maxValue, registers.Max(r => r.Value));
            }

            return maxValue;
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
