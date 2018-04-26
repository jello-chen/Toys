using System.Collections.Generic;
using System.Linq;
using Toys.Lexers;

namespace Toys.Parsers
{
    public class AstTokenNode : AstNode
    {
        public AstTokenNode(Token token) => Token = token;

        public override IEnumerable<AstNode> Children => Enumerable.Empty<AstNode>();

        public override string Location => "at line " + Token.LineNumber.ToString();

        public Token Token { get; }
    }
}
