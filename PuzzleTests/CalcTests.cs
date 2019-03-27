using Puzzle;
using Xunit;

namespace PuzzleTests
{
    public class CalcTests
    {
        [Fact]
        public void TwoAndTwoIsFour()
        {
            var c = new Calc();
            Assert.Equal(4, c.Add(2, 2));
        }

        [Fact]
        public void TwoAndThreeIsFive()
        {
            var c = new Calc();
            Assert.Equal(5, c.Add(2, 3));
        }

        [Fact]
        public void ThreeMinusOneIsTwo()
        {
            var c = new Calc();
            Assert.Equal(2, c.Substract(3, 1));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(999999999, 1, 1000000000)]
        [InlineData(1000000000, 1, 1000000001)]
        public void AddTheory(int value1, int value2, int expected)
        {
            var c = new Calc();
            Assert.Equal(expected, c.Add(value1, value2));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(10, 1, 9)]
        [InlineData(100, 1, 99)]
        public void SubstractTheory(int value1, int value2, int expected)
        {
            var c = new Calc();
            Assert.Equal(expected, c.Substract(value1, value2));
        }
    }
}
