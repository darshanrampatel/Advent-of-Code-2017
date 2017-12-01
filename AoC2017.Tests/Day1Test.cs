using Xunit;

namespace AoC2017.Tests
{
    public class Day1Test
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void Part1(string input, int output)
        {
            var result = Day1.Part1(input);
            Assert.True(result == output);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void Part2(string input, int output)
        {
            var result = Day1.Part2(input);
            Assert.True(result == output);
        }
    }
}
