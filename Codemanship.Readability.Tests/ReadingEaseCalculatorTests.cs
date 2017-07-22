using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class ReadingEaseCalculatorTests
    {
        [TestCase(@"int x = 0; 
                    int y = 4;", 3)]
        [TestCase("", 0)] // check doesn't divide by zero
        public void CalculatesAverageWordsPerStatement(string input, double expected)
        {
            SourceTokenizer sourceTokenizer = new SourceTokenizer();
            CamelPascalCaseParser camelPascalCaseParser = new CamelPascalCaseParser();
            Assert.That(new ReadingEaseCalculator(input, new SyllableCounter(), new LineCounter(), new SourceCodeParser(sourceTokenizer, camelPascalCaseParser)).WordsPerLine(), Is.EqualTo(expected));
        }

        [TestCase("foobar fee fifofum", 2)]
        [TestCase("", 0)]
        public void CalculatesAverageSyllablesPerWord(string input, double expected)
        {
            SourceTokenizer sourceTokenizer = new SourceTokenizer();
            CamelPascalCaseParser camelPascalCaseParser = new CamelPascalCaseParser();
            Assert.That(new ReadingEaseCalculator(input, new SyllableCounter(), new LineCounter(), new SourceCodeParser(sourceTokenizer, camelPascalCaseParser)).SyllablesPerWord(), Is.EqualTo(expected));
        }

        [Test]
        public void CalculatesFleschReadingEase()
        {
            string input = @"int longVariableNameWithManySyllables = 0; 
                            longVariableNameWithManySyllables++ ; 
                            maryHadALittleLambAntidisestablishmentarianism 
                                = longVariableNameWithManySyllables * longVariableNameWithManySyllables;";
            SourceTokenizer sourceTokenizer = new SourceTokenizer();
            CamelPascalCaseParser camelPascalCaseParser = new CamelPascalCaseParser();
            var readingEaseCalculator = new ReadingEaseCalculator(input, 
                new SyllableCounter(), 
                new LineCounter(), 
                new SourceCodeParser(sourceTokenizer, camelPascalCaseParser));
            var readingEase = readingEaseCalculator.ReadingEase();
            Assert.That(readingEase, Is.EqualTo(51.6).Within(0.1));
        }
    }
}
