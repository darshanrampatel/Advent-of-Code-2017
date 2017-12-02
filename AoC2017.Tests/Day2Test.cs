using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day2Test
    {
        [Theory]
        [InlineData("5 1 9 5", 8)]
        [InlineData("7 5 3  ", 4)]
        [InlineData("2 4 6 8", 6)]
        public void Part1a(string input, int output)
        {
            var result = Day2.Part1RowDifference(input.Replace(" ", "\t").ToString());
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"5 1 9 5
7 5 3  
2 4 6 8", 18)]
        public void Part1(string input, int output)
        {
            var result = Day2.Part1(input.Replace(" ", "\t").ToString());
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("5 9 2 8", 4)]
        [InlineData("9 4 7 3", 3)]
        [InlineData("3 8 6 5", 2)]
        public void Part2a(string input, int output)
        {
            var result = Day2.Part2RowDifference(input.Replace(" ", "\t").ToString());
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"5 9 2 8
9 4 7 3
3 8 6 5", 9)]
        public void Part2(string input, int output)
        {
            var result = Day2.Part2(input.Replace(" ", "\t").ToString());
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
