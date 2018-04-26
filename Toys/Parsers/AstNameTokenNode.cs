using Toys.Lexers;

namespace Toys.Parsers
{
    public class AstNameTokenNode : AstTokenNode
    {
        public AstNameTokenNode(Token token) : base(token) { }

        public string Name => Token.Text;
    }
}
