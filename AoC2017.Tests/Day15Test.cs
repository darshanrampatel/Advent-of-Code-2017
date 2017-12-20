using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day15Test
    {
        [Theory]
        [InlineData(@"Generator A starts with 65
Generator B starts with 8921", 588)]
        public void Part1(string input, int output)
        {
            var result = Day15.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"Generator A starts with 65
Generator B starts with 8921", 309)]
        public void Part2(string input, int output)
        {
            var result = Day15.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
