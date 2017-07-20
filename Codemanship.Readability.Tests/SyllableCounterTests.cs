using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class SyllableCounterTests
    {
        [TestCase("a", 1)]
        [TestCase("At", 1)]
        [TestCase("foo", 1)]
        [TestCase("newfoo", 2)]
        [TestCase("fooey", 2)]
        [TestCase("poole", 1)]
        [TestCase("fooled", 1)]
        [TestCase("Temporarily", 5)]
        [TestCase("hypocrisy", 4)]
        public void CountsSyllablesInWord(string input, int expected)
        {
            Assert.That(new SyllableCounter().Count(input), Is.EqualTo(expected));
        }
    }
}
