using System;
using System.Collections.Generic;

namespace Puzzle
{
    public class WoordZoeker
    {
        private IList<string> _grid = new List<string>();
        public WoordZoeker()
        {
        }

        public void Init(int rows, int columns)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    _grid.Add("");
                }
            }
        }

        public void Init(IList<string> raster)
        {
            if (raster == null)
            {
                throw new ArgumentNullException(nameof(raster));
            }

            foreach (string row in raster)
            {
                char[] charArray = row.ToCharArray();
                string letters = string.Empty;

                foreach(var letter in charArray)
                {
                    letters += letter + ",";
                }
                    _grid.Add(letters.Trim(','));
            }
        } 

        public IList<string> Grid => _grid;
    }
}
