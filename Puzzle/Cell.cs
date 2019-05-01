namespace Puzzle
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string Value { get; private set; }

        public Cell(int row, int column, string value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
    }
}