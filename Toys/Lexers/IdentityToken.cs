namespace Toys.Lexers
{
    public class IdentityToken : Token
    {
        public string Identity { get; }

        public override bool IsIdentifier => true;
        public override string Text => Identity.Replace("\r", "\\r").Replace("\n", "\\n");

        public IdentityToken(int lineNumber, int start, int end, string identity) : base(lineNumber, start, end) => Identity = identity;
    }
}
