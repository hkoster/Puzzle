using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    public class ZeroOne
    {
        private Grid _grid;
        private Cell _cellA;
        private Cell _cellB;
        private Cell _cellC;

        public Grid Grid
        {
            get { return _grid; }
        }

        public void AddLine(int row, int column, string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentException("nothing to add", nameof(line));
            }

            _grid = new Grid(row, column, line);
        }

        public void Resolve()
        {
            for (int row = 1; row <= _grid.MaxRows; row++)
            {
                for (int column = 1; column <= _grid.MaxColumns; column++)
                {
                    GetStepCells(row, column);

                    if (findTheMiddle(_cellA.Value, _cellB.Value, _cellC.Value))
                    {
                        string newValue = _cellC.Value;
                        if (_cellA.Value == "0") newValue = "1";
                        else newValue = "0";

                        _grid.SetCell(_cellB.Row, _cellB.Column, newValue);
                    }

                    if (findNeighbors(_cellA.Value, _cellB.Value))
                    {
                        string newValue = _cellC.Value;
                        if (_cellA.Value == "0") newValue = "1";
                        if (_cellA.Value == "1") newValue = "0";

                        _grid.SetCell(_cellC.Row, _cellC.Column, newValue);
                    }

                    if (findNeighbors(_cellB.Value, _cellC.Value))
                    {
                        string newValue = _cellA.Value;
                        if (_cellB.Value == "0") newValue = "1";
                        if (_cellB.Value == "1") newValue = "0";

                        _grid.SetCell(_cellA.Row, _cellA.Column, newValue);
                    }

                    if ((column + 2) == _grid.MaxColumns) break;
                }

                if ((row + 2) == _grid.MaxRows) break;
            }
        }

        private bool findNeighbors(string first, string second)
        {
            if (first == second) return true;
            return false;
        }

        private bool findTheMiddle(string a, string b, string c)
        {
            if (a != b && b == "x") return true;
            return false;
        }
        private void GetStepCells(int row, int column)
        {
            _cellA = _grid.GetCell(row, column);
            _cellB = _grid.GetCell(row, column + 1);
            _cellC = _grid.GetCell(row, column + 2);
        }

    }
}
