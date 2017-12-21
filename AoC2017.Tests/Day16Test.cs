using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AoC2017.Tests
{
    public class Day16Test
    {
        [Theory]
        [InlineData("s1,x3/4,pe/b", 5, "baedc")]
        public void Part1(string input, int letters, string output)
        {
            var result = Day16.Part1(input, letters);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
