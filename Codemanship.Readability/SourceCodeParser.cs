using System.Linq;

namespace Codemanship.Readability
{
    public class SourceCodeParser : IParser
    {
        private readonly ITokenizer _sourceTokenizer;
        private readonly IParser _camelPascalCaseParser;

        public SourceCodeParser(ITokenizer sourceTokenizer, IParser camelPascalCaseParser)
        {
            _sourceTokenizer = sourceTokenizer;
            _camelPascalCaseParser = camelPascalCaseParser;
        }

        public string[] Parse(string source)
        {
            string[] tokens = _sourceTokenizer.Tokenize(source);
            return tokens
                .SelectMany(_camelPascalCaseParser.Parse)
                .ToArray();
        }
    }
}