using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day14Test
    {
        [Theory]
        [InlineData("flqrgnkx", 8108)]
        public void Part1(string input, int output)
        {
            var result = Day14.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("flqrgnkx", 1242)]
        public void Part2(string input, int output)
        {
            var result = Day14.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
