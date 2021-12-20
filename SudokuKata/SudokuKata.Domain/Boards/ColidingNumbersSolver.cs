namespace SudokuKata.Domain.Boards
{
    public class ColidingNumbersSolver
    {
        private readonly int row;
        private readonly int col;
        private readonly int blockRow;
        private readonly int blockCol;

        public ColidingNumbersSolver(int row, int col, int blockRow, int blockCol)
        {
            this.row = row;
            this.col = col;
            this.blockRow = blockRow;
            this.blockCol = blockCol;
        }

        public int CalculateColidingNumbers(int[] state)
        {
            int colidingNumbers = 0;
            for (int j = 0; j < 9; j++)
            {
                int rowSiblingIndex = 9 * row + j;
                int colSiblingIndex = 9 * j + col;
                int blockSiblingIndex = 9 * (blockRow * 3 + j / 3) + blockCol * 3 + j % 3;

                int rowSiblingMask = 1 << (state[rowSiblingIndex] - 1);
                int colSiblingMask = 1 << (state[colSiblingIndex] - 1);
                int blockSiblingMask = 1 << (state[blockSiblingIndex] - 1);

                colidingNumbers = colidingNumbers | rowSiblingMask | colSiblingMask | blockSiblingMask;
            }

            return colidingNumbers;
        }
    }
}
