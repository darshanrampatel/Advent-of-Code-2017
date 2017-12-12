using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day10Test
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, 3, 0, 0, new int[] { 2, 1, 0, 3, 4 }, 3, 1)]
        [InlineData(new int[] { 2, 1, 0, 3, 4 }, 4, 3, 1, new int[] { 4, 3, 0, 1, 2 }, 3, 2)]
        [InlineData(new int[] { 4, 3, 0, 1, 2 }, 1, 3, 2, new int[] { 4, 3, 0, 1, 2 }, 1, 3)]
        [InlineData(new int[] { 4, 3, 0, 1, 2 }, 5, 1, 3, new int[] { 3, 4, 2, 1, 0 }, 4, 4)]
        public void Part1Tests(int[] input, int inputLength, int inputPosition, int inputSkipSize, IEnumerable<int> outputList, int outputPosition, int outputSkipSize)
        {
            var (output, skipSize, currentPosition) = Day10.ReverseInput(input.ToList(), inputLength, inputSkipSize, inputPosition);
            Assert.True(output.SequenceEqual(outputList), $"List Expected: {String.Join(",", outputList)}, Received: {String.Join(",", output)}");
            Assert.True(currentPosition == outputPosition, $"Position Expected: {outputPosition}, Received: {currentPosition}");
            Assert.True(skipSize == outputSkipSize, $"SkipSize Expected: {outputSkipSize}, Received: {skipSize}");
        }

        [Theory]
        [InlineData("3, 4, 1, 5", 5, 12)]
        public void Part1(string input, int listLength, int output)
        {
            var result = Day10.Part1(input, listLength);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part2(string input, string output)
        {
            var result = Day10.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
