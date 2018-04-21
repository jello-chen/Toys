namespace Toys.Lexers
{
    public class StringToken : Token
    {
        public string Literal { get; }

        public override bool IsString => true;
        public override string Text => Literal;

        public StringToken(int lineNumber, int start, int end, string literal) : base(lineNumber, start, end) => Literal = literal;
    }
}
