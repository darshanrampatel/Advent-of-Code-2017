using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day9Test
    {
        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 3)]
        [InlineData("{{},{}}", 3)]
        [InlineData("{{{},{},{{}}}}", 6)]
        [InlineData("{<{},{},{{}}>}", 1)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [InlineData("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        public void Part1Groups(string input, int output)
        {
            var result = Day9.CalculateNumberOfGroups(input);
            Assert.True(result.groups == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Part1(string input, int output)
        {
            var result = Day9.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void Part2(string input, int output)
        {
            var result = Day9.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
