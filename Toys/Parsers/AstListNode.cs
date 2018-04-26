using System.Collections.Generic;

namespace Toys.Parsers
{
    public class AstListNode : AstNode
    {
        private readonly List<AstNode> nodes;
        public AstListNode(List<AstNode> nodes) => this.nodes = nodes;

        public override IEnumerable<AstNode> Children => nodes;

        public override string Location
        {
            get
            {
                foreach (var child in Children)
                {
                    string location = child.Location;
                    if (location != null) return location;
                }
                return null;
            }
        }

        public override IEnumerator<AstNode> GetEnumerator() => nodes.GetEnumerator();
    }
}
