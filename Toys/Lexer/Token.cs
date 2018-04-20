using System;

namespace Toys.Lexer
{
    public class Token
    {
        private readonly int lineNumber;

        public static readonly Token EOF = new Token(-1);
        public static readonly string EOL = Environment.NewLine;

        public int LineNumber => lineNumber;
        public bool IsIdentifier => false;
        public bool IsNumber => false;
        public bool IsString => false;
        public int Number => throw new ToysException();
        public string Text => string.Empty;

        protected Token(int lineNumber) => this.lineNumber = lineNumber;
    }
}
