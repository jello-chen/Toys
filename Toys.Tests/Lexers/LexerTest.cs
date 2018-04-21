using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Toys.Lexers;

namespace Toys.Tests.Lexers
{
    [TestClass]
    public class LexerTest
    {
        [TestMethod]
        public void Test_Read()
        {
            string input = @"while i < 10 // Sum from 0 to 9
                          {
                            sum = sum + i
                            i = i + 1
                          }
                          sum";
            using (Lexer lexer = new Lexer(new StringReader(input)))
            {
                Token token = lexer.Read();
                Assert.AreEqual(token.Text, "while");
                Assert.AreEqual(token.IsIdentifier, true);
                Assert.AreEqual(token.LineNumber, 1);
                Assert.AreEqual(token.Start, 0);
                Assert.AreEqual(token.End, 4);

                token = lexer.Read();
                Assert.AreEqual(token.Text, "i");
                Assert.AreEqual(token.IsIdentifier, true);
                Assert.AreEqual(token.LineNumber, 1);
                Assert.AreEqual(token.Start, 6);
                Assert.AreEqual(token.End, 6);

                token = lexer.Read();
                Assert.AreEqual(token.Text, "<");
                Assert.AreEqual(token.IsIdentifier, true);
                Assert.AreEqual(token.LineNumber, 1);
                Assert.AreEqual(token.Start, 8);
                Assert.AreEqual(token.End, 8);

                token = lexer.Read();
                Assert.AreEqual(token.Text, "10");
                Assert.AreEqual(token.IsNumber, true);
                Assert.AreEqual(token.LineNumber, 1);
                Assert.AreEqual(token.Start, 10);
                Assert.AreEqual(token.End, 11);

                token = lexer.Read();
                Assert.AreEqual(token.Text, "// Sum from 0 to 9");
                Assert.AreEqual(token.IsComment, true);
                Assert.AreEqual(token.LineNumber, 1);
                Assert.AreEqual(token.Start, 13);
                Assert.AreEqual(token.End, 30);
            }
        }
    }
}
