using NUnit.Framework;
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
        private static Token ReadQoted(string line, int startIndex, char check)
        {
            var result = new StringBuilder();
            var len = 0;

            for (int i = startIndex + 1; i < line.Length; i++)
            {
                if (line[i] == '\\' && line[i + 1] == check)
                {
                    len++;
                    continue;
                }

                if (line[i] == check && line[i - 1] != '\\')
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
