namespace SudokuKata.Domain.Boards
{
    public record BoardPosition
    {
        public int X { get; }
        public int Y { get; }
        public BoardPosition(int i, int nRows = 9, int nCols = 9)
        {
            X = ToRow(i, nRows);
            Y = ToColumn(i, nCols);
        }

        public (int,int) ToDisplayRowCol() =>
            (ToDisplayCoordinates(X), ToDisplayCoordinates(Y));

        public (int, int) ToBlockCoordinates(int blockSize = 3) =>
            (X / blockSize, Y / blockSize);

        public static int ToRow(int i, int nRows) =>
            i / nRows;
        public static int ToColumn(int i, int nCols) =>
            i % nCols;
        private static int ToDisplayCoordinates(
            int coordinate, 
            int blockDimension = 3,
            int separatorRow = 1) =>
            coordinate + (coordinate / blockDimension) + separatorRow;

    }
}
