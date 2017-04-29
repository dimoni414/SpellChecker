using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace SimpleBlank.Services
{
    internal class SupplementWordService
    {

        public SupplementWordService()
        {
            _sb = new StringBuilder();
        }
        public List<string> Supplement(string inputWord)
        {
            if (inputWord.Length==0)
            {
                return null;
            }
            var supplementWords = from word in BaseDictionary.dictionary
                                  where word.Key.StartsWith(inputWord.ToLower())
                                  orderby word.Value descending
                                  select word.Key;

            return supplementWords.Take(7).ToList();
        }
        public string GetCurrentWord(string inputingText,int caretIndex)
        {
            _sb.Clear();
            var preResult = inputingText.Substring(0, caretIndex).Reverse().TakeWhile(ch => char.IsLetter(ch)).Reverse();
            foreach (var ch in preResult)
            {
                _sb.Append(ch);
            }
            return _sb.ToString();
        }

        public void ReplaceSupplamentWord(MainViewModel vm  , string supplementWord)
        {
            var subStr = vm.InputingText.Substring(0, vm.CaretIndex);
            var preStartIndex = subStr.LastIndexOf(' ');
            var startIndex = (preStartIndex < 0 ? 0 : (preStartIndex + 1));
            var delStr = vm.InputingText.Remove(startIndex, subStr.Length - startIndex);
            vm.InputingText= delStr.Insert(startIndex, supplementWord);
            vm.CaretIndex = startIndex + supplementWord.Length;
        }

        private StringBuilder _sb;

    }
}