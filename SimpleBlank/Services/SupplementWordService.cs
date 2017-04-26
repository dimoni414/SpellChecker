using System.Collections.Generic;
using System.Linq;

namespace SimpleBlank.Services
{
    public class SupplementWordService : BaseDictionary
    {
        public List<string> Supplement(string inputWord)
        {
            var supplementWords = from word in _dictionary
                                  where word.Key.Contains(inputWord.ToLower()П)
                                  where word.Key.Length > inputWord.Length
                                  orderby word.Value descending
                                  select word.Key;
            return supplementWords.ToList();
        }
    }
}