using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day5Test
    {
        [Theory]
        [InlineData(@"0
3
0
1
-3", 5)]
        public void Part1(string input, int output)
        {
            var result = Day5.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"0
3
0
1
-3", 10)]
        public void Part2(string input, int output)
        {
            var result = Day5.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
