using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codemanship.Readability.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void OutputsReadingEaseCalculationResult()
        {
            string input = @"int longVariableNameWithManySyllables = 0; 
                            longVariableNameWithManySyllables++ ; 
                            maryHadALittleLambAntidisestablishmentarianism 
                                = longVariableNameWithManySyllables * longVariableNameWithManySyllables;";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.Main(new string[]{input});

            Assert.That(stringWriter.ToString().Contains("51.60"));
        }
    }
}
