using System.IO;
using System.Threading.Tasks;

namespace Toys.Readers
{
    internal class LineNumberReader : TextReader
    {
        public int LineNumber { get; private set; }
        private readonly TextReader reader;
        public LineNumberReader(TextReader reader)
        {
            this.reader = reader;
        }

        public override string ReadLine()
        {
            string line = reader.ReadLine();
            if(line != null)
            {
                LineNumber++;
            }
            return line;
        }

        public override async Task<string> ReadLineAsync()
        {
            string line = await reader.ReadLineAsync();
            if (line != null)
            {
                LineNumber++;
            }
            return line;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            reader?.Dispose();
        }
    }
}
