namespace SudokuKata
{
    public interface IRandomService
    {
        int Next();
        int Next(int max);
    }
}
