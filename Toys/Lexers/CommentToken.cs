using System;
using System.Collections.Generic;
using System.Text;

namespace Toys.Lexers
{
    public class CommentToken : Token
    {
        private readonly string comment;

        public override bool IsComment => true;
        public override string Text => comment;

        public CommentToken(int lineNumber, int start, int end, string comment) : base(lineNumber, start, end)
        {
            this.comment = comment;
        }
    }
}
