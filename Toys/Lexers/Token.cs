using System;
using System.Diagnostics;

namespace Toys.Lexers
{
    [DebuggerDisplay("Text: {Text}, Line: {LineNumber}, Col: [{Start}-{End}]")]
    public class Token
    {
        private readonly int lineNumber;
        private readonly int start;
        private readonly int end;

        public static readonly Token EOF = new Token(-1, -1, -1);
        public static readonly string EOL = Environment.NewLine;

        public int LineNumber => lineNumber;
        public int Start => start;
        public int End => end;

        public int Number => throw new ToysException();
        public virtual bool IsComment => false;
        public virtual bool IsIdentifier => false;
        public virtual bool IsNumber => false;
        public virtual bool IsString => false;
        public virtual string Text => string.Empty;

        protected Token(int lineNumber, int start, int end)
        {
            this.lineNumber = lineNumber;
            this.start = start;
            this.end = end;
        }
    }
}
