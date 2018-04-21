using System;
using System.IO;
using Toys.Lexers;

namespace Toys.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"while i < 10 // Sum from 0 to 9
                          {
                            sum = sum + i
                            i = i + 1
                          }
                          sum";
            using (Lexer lexer = new Lexer(new StringReader(s)))
            {
                Token token = null;
                while ((token = lexer.Read()) != Token.EOF)
                {
                    Console.WriteLine($"Text: {token.Text}, Line: {token.LineNumber}, Col: [{token.Start}-{token.End}], Type: {token.GetType().Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
