using Toys.Lexers;

namespace Toys.Parsers
{
    public class AstNumberTokenNode : AstTokenNode
    {
        public AstNumberTokenNode(NumberToken token) : base(token) { }

        public int Value => Token.Number;
    }
}
