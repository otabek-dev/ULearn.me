using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }
    }

    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            var tokens = new List<Token>();
            var nextIndex = 0;
            while (line.Length > nextIndex)
            {
                if (line[nextIndex] != '"' && line[nextIndex] != '\'' && line[nextIndex] != ' ')
                    tokens.Add(ReadField(line, nextIndex));
                else if (line[nextIndex] == ' ')
                {
                    nextIndex++;
                    continue;
                }
                else
                    tokens.Add(ReadQuotedField(line, nextIndex));

                nextIndex = tokens[tokens.Count - 1].GetIndexNextToToken();
            }

            return tokens;
        }
        
        private static Token ReadField(string line, int startIndex)
        {
            var lastIndex = line.IndexOfAny(new[] { ' ', '"', '\'' }, startIndex + 1);
            string result;
            if (lastIndex == -1)
                result = line.Substring(startIndex, line.Length - startIndex);
            else
                result = line.Substring(startIndex, lastIndex - startIndex);

            return new Token(result.Trim(), startIndex, result.Length);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}