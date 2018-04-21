using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Toys.Readers;

namespace Toys.Lexers
{
    public class Lexer : IDisposable
    {
        public static Regex Pattern = new Regex("\\s*((//.*)|([0-9]+)|(\"(\\\\\"|\\\\\\\\|\\\\n|[^\"])*\")|[A-Z_a-z][A-Z_a-z0-9]*|==|<=|>=|[+\\-*/<=>]|&&|\\|\\||\\p{P})?", RegexOptions.Compiled);

        private Queue<Token> tokens;
        private LineNumberReader reader;
        private bool hasMore;

        public Lexer(TextReader textReader)
        {
            tokens = new Queue<Token>();
            reader = new LineNumberReader(textReader);
            hasMore = true;
        }

        public Token Read()
        {
            if(FillTokens(0))
                return tokens.Dequeue();
            else
                return Token.EOF;
        }

        public Token Peek()
        {
            if(FillTokens(0))
                return tokens.Peek();
            else
                return Token.EOF;
        }

        private bool FillTokens(int i)
        {
            while (tokens.Count <= i)
            {
                if(hasMore)
                    ReadLine();
                else
                    return false;
            }
            return true;
        }

        private void ReadLine()
        {
            string line = reader.ReadLine();
            if(line == null)
            {
                hasMore = false;
                return;
            }

            int lineNumber = reader.LineNumber;
            int pos = 0;
            int endPos = line.Length;
            while (pos < endPos)
            {
                Match match = Pattern.Match(line, pos, endPos - pos);
                if(match.Success)
                {
                    AddToken(lineNumber, match);
                    pos = match.Index + match.Length;
                }
                else
                {
                    throw new ToysException($"Invalid token at line {lineNumber}, col {pos}.");
                }
            }
            tokens.Enqueue(new IdentityToken(lineNumber, endPos, endPos + Token.EOL.Length - 1, Token.EOL));
        }

        private void AddToken(int lineNumber, Match match)
        {
            Group g = match.Groups[1];
            string m = g.Value;
            if(m != "") // if not a space
            {
                Token token = null;
                if (match.Groups[2].Value == "") // if not a comment
                {
                    if(match.Groups[3].Value != "")
                    {
                        token = new NumberToken(lineNumber, g.Index, g.Index + g.Length - 1, int.Parse(m));
                    }
                    else if(match.Groups[4].Value != "")
                    {
                        token = new StringToken(lineNumber, g.Index, g.Index + g.Length - 1, ToLiteralString(m));
                    }
                    else
                    {
                        token = new IdentityToken(lineNumber, g.Index, g.Index + g.Length - 1, m);
                    }
                }
                else
                {
                    token = new CommentToken(lineNumber, g.Index, g.Index + g.Length - 1, m);
                }
                tokens.Enqueue(token);
            }
        }

        private string ToLiteralString(string s)
        {
            StringBuilder sb = new StringBuilder();
            int length = s.Length - 1;
            for (int i = 1; i < length; i++)
            {
                char c = s[i];
                if(c == '\\' && i + 1 < length)
                {
                    char c2 = s[i + 1];
                    if(c2 == '"' || c2 == '\\')
                    {
                        c = s[++i];
                    }
                    else if(c2 == 'n')
                    {
                        ++i;
                        c = '\n';
                    }
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        public void Dispose()
        {
            reader?.Dispose();
        }
    }
}
