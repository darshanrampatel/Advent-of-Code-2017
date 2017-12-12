using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day12Test
    {
        [Theory]
        [InlineData(@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5", 6)]
        public void Part1(string input, int output)
        {
            var result = Day12.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5", 2)]
        public void Part2(string input, int output)
        {
            var result = Day12.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
