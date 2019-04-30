using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle.ZeroOne
{
    public class ZeroOneGrid
    {
        private IList<string> _grid;

        public IList<string> Grid
        {
            get { return _grid; }
        }

        public ZeroOneGrid()
        {
            _grid = new List<string>();
        }

        public void AddLine(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentException("nothing to add", nameof(line));
            }

            foreach (var item in line.Split(',').ToList<string>())
            {
                _grid.Add(item);
            }
        }

        public void Resolve()
        {
            var a = _grid[0];
            var b = _grid[1];
            var c = _grid[2];

            if (findTheMiddle(a, b, c))
            {
                if (a == "0") b = "1";
                else b = "0";

                _grid[1] = b;
            }
        }

        private bool findTheMiddle(string a, string b, string c)
        {
            if (a != b && b == "x") return true;

            return false;
        }
    }
}
