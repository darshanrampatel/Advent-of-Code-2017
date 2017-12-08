using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day7
    {
        public static string Part1(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var discs = lines.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));

            var baseDisc = GetBaseDisc(discs);
            return baseDisc.Name;
        }

        private static Disc GetBaseDisc(List<Disc> discs)
        {
            var disc = discs.First();
            while (disc.ParentDisc != null)
            {
                disc = disc.ParentDisc;
            }
            return disc;
        }

        public class Disc
        {
            public int Weight { get; private set; }
            public string Name { get; private set; }
            public List<string> ChildNames { get; private set; }
            public List<Disc> ChildDiscs { get; private set; }
            public Disc ParentDisc { get; private set; }

            public Disc(string input)
            {
                var words = input.Split(" ").ToList();

                Name = words[0];
                Weight = int.Parse(words[1].Replace("(", "").Replace(")", ""));
                ChildNames = new List<string>();

                for (var i = 3; i < words.Count; i++)
                {
                    ChildNames.Add(words[i].Replace(" ", "").Replace(",", ""));
                }
            }

            public void AddChildDiscs(IEnumerable<Disc> discs)
            {
                ChildDiscs = ChildNames.Select(x => discs.First(y => y.Name == x)).ToList();
                ChildDiscs.ForEach(x => x.ParentDisc = this);
            }
        }

        public static int Part2(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var discs = lines.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));
            var baseDisc = GetBaseDisc(discs);

            var w = GetUnbalancedDiscWeight(discs, baseDisc, 0);
            return w;
        }

        private static int GetUnbalancedDiscWeight(List<Disc> discs, Disc baseDisc, int difference)
        {
            var lists = new List<Tuple<int, Disc>>();
            foreach (var disc in baseDisc.ChildDiscs)
            {
                lists.Add(new Tuple<int, Disc>(disc.Weight + GetChildWeights(disc), disc));
            }

            var t = lists.GroupBy(d => d.Item1);
            if (t.Count() > 1)
            {
                var bad = t.First(d => d.Count() == 1).First();
                var target = t.First(d => d.Count() != 1).First().Item1;
                var diff = Math.Abs(target - bad.Item1);
                return GetUnbalancedDiscWeight(discs, bad.Item2, diff);
            }
            else
            {
                return baseDisc.Weight - difference;
            }
        }

        private static int GetChildWeights(Disc disc)
        {
            var weight = 0;
            foreach (var childDisc in disc.ChildDiscs)
            {
                weight += childDisc.Weight;
                if (childDisc.ChildDiscs.Count > 0)
                {
                    weight += GetChildWeights(childDisc);
                }
            }
            return weight;
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
