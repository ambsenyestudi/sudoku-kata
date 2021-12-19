namespace SudokuKata.Domain.Randomizing
{
    public interface IRandomService
    {
        int Next();
        int Next(int max);
    }
}
