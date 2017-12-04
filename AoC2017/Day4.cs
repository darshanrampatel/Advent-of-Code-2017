using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day4
    {
        public static int Part1(string input)
        {
            var passphrases = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return passphrases.Count(p => IsValidPassphrase(p));
        }

        public static bool IsValidPassphrase(string input)
        {
            var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distinctWords = new HashSet<string>();
            foreach (var word in words)
            {
                if (!distinctWords.Add(word))
                {
                    return false;
                }
            }
            return true;
        }

        public static int Part2(string input)
        {
            var passphrases = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return passphrases.Count(p => IsValidPassphrase2(p));
        }

        public static bool IsValidPassphrase2(string input)
        {
            var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distinctWords = new HashSet<string>( new PassphraseComparer());
            foreach (var word in words)
            {
                if (!distinctWords.Add(word))
                {
                    return false;
                }
            }
            return true;
        }

        class PassphraseComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => x.OrderBy(c => c).SequenceEqual(y.OrderBy(c => c));
            public int GetHashCode(string obj) => base.GetHashCode();
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
