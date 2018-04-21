namespace Toys.Lexers
{
    public class NumberToken : Token
    {
        public int Value { get; }

        public override bool IsNumber => true;
        public override string Text => Value.ToString();

        public NumberToken(int lineNumber, int start, int end, int value) : base(lineNumber, start, end) => Value = value;
    }
}
