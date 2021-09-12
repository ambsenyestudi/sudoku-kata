namespace SudokuKata.Rules.Domain.Common
{
    public record Square
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 9;
        public static Square Empty { get; } = new Square(0);
        public int Value { get; }
        private Square(int value) => Value = value;

        public static Square Create(int value)
        {
            if(value < MIN_VALUE || value > MAX_VALUE)
            {
                return Empty;
            }
            return new Square(value);
        }
        
    }
}
