using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day3Test
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void Part1(int input, int output)
        {
            var result = Day3.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
