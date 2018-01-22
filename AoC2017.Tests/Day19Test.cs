using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day19Test
    {
        [Theory]
        [InlineData(@"     |
     |  +--+
     A  |  C
 F---|----E|--+
     |  |  |  D
     +B-+  +--+", "ABCDEF")]
        public void Part1(string input, string output)
        {
            var result = Day19.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"     |
     |  +--+
     A  |  C
 F---|----E|--+
     |  |  |  D
     +B-+  +--+", 38)]
        public void Part2(string input, int output)
        {
            var result = Day19.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
