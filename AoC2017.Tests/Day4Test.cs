using System;
using Xunit;

namespace AoC2017.Tests
{
    public class Day4Test
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Part1(string input, bool output)
        {
            var result = Day4.IsValidPassphrase(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void Part2(string input, bool output)
        {
            var result = Day4.IsValidPassphrase2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
