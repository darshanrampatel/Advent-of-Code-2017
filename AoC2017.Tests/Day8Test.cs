using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day8Test
    {
        [Theory]
        [InlineData(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10", 1)]
        public void Part1(string input, int output)
        {
            var result = Day8.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10", 10)]
        public void Part2(string input, int output)
        {
            var result = Day8.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
