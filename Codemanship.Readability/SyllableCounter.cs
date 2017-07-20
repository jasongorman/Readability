using System.Text.RegularExpressions;

namespace Codemanship.Readability
{
    public class SyllableCounter
    {
        public int Count(string word)
        {
            word = word.ToLower();                                     
            if(word.Length < 3) { return 1; }
            word = Regex.Replace(word, @"(?:es|ed|e)$", "");             
            return Regex.Matches(word, @"[aeiouy]{1,2}").Count;
        }
    }
}