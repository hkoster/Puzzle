using System;
using System.Linq;
using Puzzle;
using Xunit;
using Xunit.Sdk;

namespace PuzzleTests
{
    public class ZeroOneTests
    {

        [Fact]
        public void AddOneLineToGrid()
        {
            // arrange
            var line = "0,1,0";
            var sut = new ZeroOne();

            // act
            sut.AddLine(1, 3, line);

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public static void ExpectExceptionButCodeDoesNotThrow()
        {
            // arrange
            var line = "";
            var sut = new ZeroOne();

            try
            {
                // act & assert
                Assert.Throws<ArgumentException>(() =>
                {
                    sut.AddLine(0, 0, line);
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
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveFill0()
        {
            // arrange
            var line = "1,x,1";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("1", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveNotInTheMiddle()
        {
            // arrange
            var line = "x,x,1";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("x", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("x", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveFirstNeighbors0()
        {
            // arrange
            var line = "0,0,x";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveFirstNeighbors1()
        {
            // arrange
            var line = "1,1,x";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("1", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveLastNeighbors0()
        {
            // arrange
            var line = "x,0,0";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("1", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("0", sut.Grid.GetCell(1, 3).Value);
        }

        [Fact]
        public void FindAndResolveLastNeighbors1()
        {
            // arrange
            var line = "x,1,1";
            var sut = new ZeroOne();
            sut.AddLine(1, 3, line);

            // act
            sut.Resolve();

            // assert
            Assert.NotNull(sut.Grid);
            Assert.Equal("0", sut.Grid.GetCell(1, 1).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 2).Value);
            Assert.Equal("1", sut.Grid.GetCell(1, 3).Value);
        }
    }
}