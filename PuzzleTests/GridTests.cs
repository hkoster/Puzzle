using System;
using System.Linq;
using Puzzle;
using Xunit;
using Xunit.Sdk;

namespace GridTests
{
    public class GridTests
    {
        [Fact]
        public void FillEmptyLine()
        {
            // arrange
            var line = "";

            try
            {
                // act & assert
                Assert.Throws<ArgumentException>(() =>
                {
                    var sut = new Grid(0, 0, line);
                });
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void FillLineOneCell()
        {
            // arrange
            var line = "0";

            // act
            var sut = new Grid(1, 1, line);

            // assert
            Assert.Equal(1, sut.MaxRows);
            Assert.Equal(1, sut.MaxColumns);
            Assert.Single(sut.Cells);
            Assert.Equal("0", sut.GetCell(1, 1).Value);
        }

        [Fact]
        public void FillLineTwoCells()
        {
            // arrange
            var line = "0,1";

            // act
            var sut = new Grid(1, 2, line);

            // assert
            Assert.Equal(1, sut.MaxRows);
            Assert.Equal(2, sut.MaxColumns);
            Assert.Equal(2, sut.Cells.Count());
            Assert.Equal("0", sut.GetCell(1, 1).Value);
            Assert.Equal("1", sut.GetCell(1, 2).Value);
        }

        [Theory]
        [InlineData(1, 1, "0")]
        [InlineData(1, 2, "0,0")]
        [InlineData(1, 3, "0,0,0")]
        [InlineData(2, 2, "0,0,0,0")]
        [InlineData(3, 3, "0,0,0,0,0,0,0,0,0")]
        public void FillLineMultipleCells(int row, int column, string line )
        { 
            // arrange
            // act
            var sut = new Grid(row, column, line);

            // assert
            Assert.Equal(row, sut.MaxRows);
            Assert.Equal(column, sut.MaxColumns);
            Assert.Equal(line.Split(',').ToList().Count(), sut.Cells.Count());
        }
    }
}