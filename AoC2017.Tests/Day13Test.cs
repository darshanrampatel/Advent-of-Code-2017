using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day13Test
    {
        [Theory]
        [InlineData(@"0: 3
1: 2
4: 4
6: 4", 24)]
        public void Part1(string input, int output)
        {
            var result = Day13.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"0: 3
1: 2
4: 4
6: 4", 10)]
        public void Part2(string input, int output)
        {
            var result = Day13.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
