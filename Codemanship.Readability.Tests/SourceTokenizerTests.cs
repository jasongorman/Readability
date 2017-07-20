using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class SourceTokenizerTests
    {
        [TestCase("class", new string[]{"class"})]
        [TestCase("public class", new string[] { "public", "class"})]
        [TestCase("12 monkeys", new string[]{"12", "monkeys"})]
        public void TokenizesSingleWord(string input, string[] expected)
        {
            string[] tokens = new SourceTokenizer().Tokenize(input);
            Assert.That(tokens, Is.EqualTo(expected));
        }
    }
}
