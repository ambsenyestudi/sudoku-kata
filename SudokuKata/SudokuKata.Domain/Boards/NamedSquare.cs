namespace SudokuKata.Domain.Boards
{
    public class NamedSquare
    {
        public int Discriminator { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
