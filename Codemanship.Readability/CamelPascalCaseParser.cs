using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codemanship.Readability
{
    public class CamelPascalCaseParser : IParser
    {
        public string[] Parse(string source)
        {
            if (source.ToCharArray().All(Char.IsNumber))
                return new string[]{source};

            return new Regex(@"(?<=[a-z0-9])(?=[A-Z0-9])")
                .Split(source)
                .ToArray();
        }
    }
}