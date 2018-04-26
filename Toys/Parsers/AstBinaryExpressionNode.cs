using System.Collections.Generic;
using System.Linq;

namespace Toys.Parsers
{
    public class AstBinaryExpressionNode : AstListNode
    {
        public AstBinaryExpressionNode(List<AstNode> nodes) : base(nodes) { }

        public AstNode Left => Children.ElementAt(0);
        public string Operator => ((AstTokenNode)Children.ElementAt(1)).Token.Text;
        public AstNode Right => Children.ElementAt(2);
    }
}
