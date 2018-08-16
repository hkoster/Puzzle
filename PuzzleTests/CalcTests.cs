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
    }
}
