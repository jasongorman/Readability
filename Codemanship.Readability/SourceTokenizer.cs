using System.Linq;
using System.Text.RegularExpressions;

namespace Codemanship.Readability
{
    public class SourceTokenizer : ITokenizer
    {
        public string[] Tokenize(string source)
        {
            return new Regex(@"\w+").Matches(source).Cast<Match>().Select(m => m.ToString()).ToArray();
        }
    }
}