using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Toys.Parsers
{
    public abstract class AstNode : IEnumerable<AstNode>
    {
        public virtual int ChildrenCount => Children.Count();

        public virtual AstNode GetChild(int index) => Children.ElementAt(index);

        public abstract IEnumerable<AstNode> Children { get; }

        public abstract string Location { get; }

        public virtual IEnumerator<AstNode> GetEnumerator() => Children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
