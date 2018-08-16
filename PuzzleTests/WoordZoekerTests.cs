using System;
using System.Collections.Generic;
using Puzzle;
using Xunit;

namespace PuzzleTests
{
    public class WoordZoekerTests : IDisposable
    {
        private List<string> _raster;

        public WoordZoekerTests()
        {
            _raster = new List<string>();
            _raster.Add("BOGNITTOR");
            _raster.Add("UKAAHKERT");
            _raster.Add("IYDTSOORT");
            _raster.Add("TKRAPTERP");
            _raster.Add("WGEYLIURG");
            _raster.Add("AEDXKIKSE");
            _raster.Add("SLAMTSEEV");
            _raster.Add("KDVHERWNO");
            _raster.Add("NKATEOAEL");
            _raster.Add("IAISSTRGG");
            _raster.Add("LGITTAKEG");
            _raster.Add("SEVERNBDB");
        }

        public void Dispose()
        {
            _raster = null;
        }

        [Fact]
        public void WoordZoeker_New_WoordZoeker_Creates_empty_Grid()
        {
            // Arrange
            var sut = new WoordZoeker();

            // Act

            // Assert
            Assert.NotNull(sut.Grid);
            Assert.Equal(0, sut.Grid.Count);
        }

        [Fact]
        public void WoordZoeker_Init_With_One_Row_and_One_Column_Creates_Grid_with_One_Cell()
        {
            // Arrange
            var sut = new WoordZoeker();

            // Act
            sut.Init(1, 1);

            // Assert
            Assert.NotNull(sut.Grid);
            Assert.Equal(1, sut.Grid.Count);
        }

        [Fact]
        public void WoordZoeker_Init_With_null_Grid_Throws_ArgumentNullException()
        {
            // Arrange
            var sut = new WoordZoeker();

            // Act
            var exception = Record.Exception(() => sut.Init(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void WoordZoeker_Init_With_Filled_Grid_Creates_Grid_with_Twelve_Rows()
        {
            // Arrange
            var sut = new WoordZoeker();

            // Act
            sut.Init(_raster);

            // Assert
            Assert.NotNull(sut.Grid);
            Assert.Equal(12, sut.Grid.Count);
        }

        [Fact]
        public void WoordZoeker_Init_With_Filled_Grid_Creates_Grid_with_Twelve_Rows_and_Nine_Columns()
        {
            // Arrange
            var sut = new WoordZoeker();

            // Act
            sut.Init(_raster);

            // Assert
            Assert.NotNull(sut.Grid);
            Assert.Equal(12, sut.Grid.Count);
            var letters = sut.Grid[0].Split(',');
            Assert.Equal(9, letters.Length);
            Console.WriteLine(sut.Grid[0]);
        }

    }
}
