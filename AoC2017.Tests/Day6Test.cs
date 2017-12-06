using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day6Test
    {
        [Theory]
        [InlineData("0	2	7	0", 5)]
        public void Part1(string input, int output)
        {
            var result = Day6.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("0	2	7	0", 4)]
        public void Part2(string input, int output)
        {
            var result = Day6.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
