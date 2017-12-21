using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day17Test
    {
        [Theory]
        [InlineData("3", 638)]
        public void Part1(string input, int output)
        {
            var result = Day17.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
