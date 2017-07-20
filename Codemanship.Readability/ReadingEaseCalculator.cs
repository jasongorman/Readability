using System.Linq;

namespace Codemanship.Readability
{
    public class ReadingEaseCalculator
    {
        private readonly string _source;
        private readonly string[] _words;
        private readonly SyllableCounter _syllableCounter;
        private readonly LineCounter _lineCounter;

        public ReadingEaseCalculator(string source,
            SyllableCounter syllableCounter,
            LineCounter lineCounter,
            IParser sourceWordParser)
        {
            _syllableCounter = syllableCounter;
            _lineCounter = lineCounter;
            _source = source;
            _words = sourceWordParser.Parse(_source);
        }

        public double WordsPerLine()
        {
            var lineCount = _lineCounter.Count(_source);
            if (lineCount == 0) return 0;
            return (double) _words.Count()/lineCount;
        }

        public double SyllablesPerWord()
        {
            if (_words.Length == 0) return 0;
            int syllableCount = _words.Sum(w => _syllableCounter.Count(w));
            return (double) syllableCount/_words.Length;
        }

        public double ReadingEase()
        {
            return 206.835 - (1.015*WordsPerLine()) - (84.6*SyllablesPerWord());
        }
    }
}