using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codemanship.Readability
{
    public class LineCounter
    {
        public int Count(string source)
        {
            return Regex
                .Split(source, @"(^|\r*\n)")
                .Count(
                    s => s.Any(Char.IsLetterOrDigit)
                );
        }
    }
}