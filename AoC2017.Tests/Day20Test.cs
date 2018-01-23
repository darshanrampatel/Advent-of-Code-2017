using Xunit;

namespace AoC2017.Tests
{
    public class Day20Test
    {
        [Theory]
        [InlineData(@"p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0> ", 0)]
        public void Part1(string input, int output)
        {
            var result = Day20.Part1(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }

        [Theory]
        [InlineData(@"p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>
p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>
p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>
p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>", 1)]
        public void Part2(string input, int output)
        {
            var result = Day20.Part2(input);
            Assert.True(result == output, $"Expected: {output}, Received: {result}");
        }
    }
}
