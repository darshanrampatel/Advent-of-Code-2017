using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day11Test
    {
        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part1(string input, int output)
        {
            var result = Day11.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
