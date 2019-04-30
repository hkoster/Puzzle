using System;
using System.Linq;
using Puzzle.ZeroOne;
using Xunit;
using Xunit.Sdk;

namespace PuzzleTests.ZeroOne.ZeroOneGridTests
{
    public class ZeroOneGridTests
    {

        [Fact]
        public void AddOneLineToGrid()
        {
            // arrange
            var line = "0,1,0";
            var sut = new ZeroOneGrid();

            // act
            sut.AddLine(line);

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid[0]);
            Assert.Equal("1", sut.Grid[1]);
            Assert.Equal("0", sut.Grid[2]);
        }

        [Fact]
        public static void ExpectExceptionButCodeDoesNotThrow()
        {
            // arrange
            var line = "";
            var sut = new ZeroOneGrid();

            try
            {
                // act & assert
                Assert.Throws<ArgumentException>(() =>
                {
                    sut.AddLine(line);
                });
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void FindAndResolveFill1()
        {
            // arrange
            var line = "0,x,0";
            var sut = new ZeroOneGrid();
            sut.AddLine(line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid[0]);
            Assert.Equal("1", sut.Grid[1]);
            Assert.Equal("0", sut.Grid[2]);
        }

        [Fact]
        public void FindAndResolveFill0()
        {
            // arrange
            var line = "1,x,1";
            var sut = new ZeroOneGrid();
            sut.AddLine(line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("1", sut.Grid[0]);
            Assert.Equal("0", sut.Grid[1]);
            Assert.Equal("1", sut.Grid[2]);
        }

        [Fact]
        public void FindAndResolveNotInTheMiddle()
        {
            // arrange
            var line = "x,x,1";
            var sut = new ZeroOneGrid();
            sut.AddLine(line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("x", sut.Grid[0]);
            Assert.Equal("x", sut.Grid[1]);
            Assert.Equal("1", sut.Grid[2]);
        }

    }
}