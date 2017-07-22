using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codemanship.Readability
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteHeader();

            if (args.Length == 0)
            {
                Console.WriteLine("Please select some code for us to analyse");

                return;
            }

            var readingEaseCalculator = CreateReadingEaseCalculator(args[0]);

            WriteResults(readingEaseCalculator);
        }

        private static ReadingEaseCalculator CreateReadingEaseCalculator(string source)
        {
            SourceTokenizer sourceTokenizer = new SourceTokenizer();
            CamelPascalCaseParser camelPascalCaseParser = new CamelPascalCaseParser();

            var sourceWordParser = new SourceCodeParser(sourceTokenizer, camelPascalCaseParser);

            var readingEaseCalculator =
                new ReadingEaseCalculator(source,
                    new SyllableCounter(),
                    new LineCounter(),
                    sourceWordParser
                    );

            return readingEaseCalculator;
        }

        private static void WriteResults(ReadingEaseCalculator readingEaseCalculator)
        {
            Console.WriteLine("The selected code has average {0:F} words per line",
                readingEaseCalculator.WordsPerLine());
            Console.WriteLine("The selected code has average {0:F} syllables per word",
                readingEaseCalculator.SyllablesPerWord());
            Console.WriteLine("The Reading Ease of the selected code is {0:F}",
                readingEaseCalculator.ReadingEase());
        }

        private static void WriteHeader()
        {
            Console.WriteLine("Flesch Code Reading Ease");
            Console.WriteLine("A prototype by Jason Gorman, Codemanship Ltd (2017)");
        }
    }
}
