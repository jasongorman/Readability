using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class LineCounterTests
    {
        [TestCase("", 0)]
        [TestCase("{}", 0)]
        [TestCase("foo", 1)]
        [TestCase(@"void foo()
                   { 
                        int x = 0;
                       string y = 'Hello';
                   }", 3)]
        public void CountsLinesWithWordsOrNumbers(string input, int expected)
        {
            int statementEnds = new LineCounter().Count(input);
            Assert.That(statementEnds, Is.EqualTo(expected));
        }
    }
}
