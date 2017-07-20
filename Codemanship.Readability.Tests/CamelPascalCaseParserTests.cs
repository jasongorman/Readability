using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class CamelPascalCaseParserTests
    {
        [TestCase("foo", new string[] { "foo" })]
        [TestCase("fooBar", new string[] { "foo", "Bar" })]
        [TestCase("fooBar9", new string[] { "foo", "Bar", "9" })]
        [TestCase("fooBarFum", new string[] { "foo", "Bar", "Fum" })]
        [TestCase("foo9Bar", new string[] { "foo", "9", "Bar" })]
        public void ParsesCamelCaseStrings(string input, string[] expected)
        {
            Assert.That(Parse(input), Is.EqualTo(expected));
        }

        [TestCase("Foo", new string[] { "Foo" })]
        [TestCase("FooBar", new string[] { "Foo", "Bar" })]
        [TestCase("FooBarFum", new string[] { "Foo", "Bar", "Fum" })]
        [TestCase("FooBar9", new string[] { "Foo", "Bar", "9" })]
        [TestCase("Foo9Bar", new string[] { "Foo", "9", "Bar" })]
        public void ParsesPascalCaseStrings(string input, string[] expected)
        {
            Assert.That(Parse(input), Is.EqualTo(expected));
        }

        [TestCase("9", new string[] { "9" })]
        [TestCase("99", new string[] { "99" })]
        public void NumbersAreNotParsed(string input, string[] expected)
        {
            Assert.That(Parse(input), Is.EqualTo(expected));
        }

        private string[] Parse(string input)
        {
            string[] tokens = new CamelPascalCaseParser().Parse(input);
            return tokens;
        }
    }
}
