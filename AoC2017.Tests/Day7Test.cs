using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day7Test
    {
        [Theory]
        [InlineData(@"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)", "tknk")]
        public void Part1(string input, string output)
        {
            var result = Day7.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)", 60)]
        public void Part2(string input, int output)
        {
            var result = Day7.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
