using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    internal class QuotedFieldTask
    {
        private static Token ReadQoted(string line, int startIndex, char quotes)
        {
            var result = new StringBuilder();
            var len = 0;
            var quotes2 = quotes == '"' ? '\'' : '\"';

            for (int i = startIndex + 1; i < line.Length; i++)
            {
                if (line[i] == '\\' && line[i - 1] != '\\'
                    && (i + 1 < line.Length)
                    && (line[i + 1] == quotes || line[i + 1] == quotes2 || line[i + 1] == '\\'))
                {
                    len++;
                    continue;
                }

                if (line[i] == quotes && (line[i - 1] != '\\' || (line[i - 1] == '\\' && line[i - 2] == '\\')))
                    return new Token(result.ToString(), startIndex, result.Length + len + 2);

                result.Append(line[i]);
            }

            return new Token(result.ToString(), startIndex, result.Length + len + 1);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            if (line.Length > 0)
            {
                if (line[startIndex] == '"')
                    return ReadQoted(line, startIndex, '"');

                if (line[startIndex] == '\'')
                    return ReadQoted(line, startIndex, '\'');
            }

            return new Token(line.ToString(), startIndex, line.Length - startIndex);
        }
    }
}
