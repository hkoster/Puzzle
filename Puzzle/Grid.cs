using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    public class Grid
    {
        private readonly string _line;

        public int MaxRows { get; private set; }
        public int MaxColumns { get; private set; }
        public IList<Cell> Cells { get; set; }

        public Grid(int maxRows, int maxColumns, string line)
        {
            Cells = new List<Cell>();
            MaxRows = maxRows;
            MaxColumns = maxColumns;
            _line = line;

            FillGrid();
        }

        public Cell GetCell(int row, int column)
        {
            return Cells.Where(c => c.Row == row && c.Column == column).First();
        }

        public void SetCell(int row, int column, string value)
        {
            var oldCellIndex = Cells.IndexOf(GetCell(row, column));
            Cells.RemoveAt(oldCellIndex);
            Cells.Insert(oldCellIndex, new Cell(row, column, value));
        }

        private void FillGrid()
        {
            if (string.IsNullOrEmpty(_line))
            {
                throw new ArgumentException("nothing to add", nameof(_line));
            }

            IList<Cell> grid = new List<Cell>();

            IList<string> line = _line.Split(',').ToList<string>();
            var lineCounter = 0;

            for (int row = 1; row <= MaxRows; row++)
            {
                for (int column = 1; column <= MaxColumns; column++)
                {
                    var cell = new Cell(row, column, line[lineCounter]);
                    Cells.Add(cell);
                    lineCounter++;
                }
            }
        }
    }
}