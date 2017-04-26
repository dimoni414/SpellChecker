using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleBlank.Services
{
    internal class LearningDictionaryService : BaseDictionary
    {
        private string GetFileName()
        {
            var fileDilog = new OpenFileDialog();
            return fileDilog.ShowDialog() == true ? fileDilog.FileName : "";
        }

        private string GetAllTextFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return "";
            }

            using (var streamReader = new StreamReader(path, Encoding.Default))
            {
                return streamReader.ReadToEnd();
            }
        }

        private string[] GetParticularWord(string dirtyText)
        {
            if (string.IsNullOrEmpty(dirtyText))
            {
                return null;
            }

            var textWithoutNewLine = dirtyText.Replace('\n', ' ');
            var Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";

            var stringBuilder = new StringBuilder(100000);

            foreach (var letter in textWithoutNewLine)
            {
                var lowerLetter = char.ToLower(letter);

                if (Alphabet.Contains(lowerLetter))
                {
                    stringBuilder.Append(lowerLetter);
                }
            }
            return Regex.Replace(stringBuilder.ToString(), @"\s+", " ").Split(' ');
        }

        private void AddWordsToDictionary(string[] particularsWords)
        {
            if (particularsWords == null)
            {
                return;
            }

            foreach (var word in particularsWords)
            {
                string lowerWord = word.ToLower();

                if (base._dictionary.ContainsKey(lowerWord))
                    base._dictionary[lowerWord]++;
                else
                    base._dictionary.Add(lowerWord, 1);
            }
        }
    }

    var stringBuilder = new StringBuilder(100000);
    var rightSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
            //var rightSymbols = @"[а-я]"+" ";

            foreach (var letter in allText)
            {
                var letter2 = char.ToLower(letter);

                if (rightSymbols.Contains(letter2))
                {
                    stringBuilder.Append(letter2);
                }
            }

            var list = Regex.Replace(stringBuilder.ToString(), @"\s+", " ").Split(' ');
var shortList = list.Distinct();

//var sortedItems = from words in shortList
//                  orderby words
//                  select words;
//var sortedArray = sortedItems.ToArray();

var binaryFormatter = new BinaryFormatter();

var nameDictionary = "sortedDictionary.data";

            using (var fStream = new FileStream(nameDictionary
                    , FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                if (new FileInfo(nameDictionary).Length > 0)
                {
                    oldDictionary= binaryFormatter.Deserialize(fStream) as Array;
                }
                shortList.ToList().AddRange(oldDictionary);
                    .Serialize(fStream, sortedArray);
            }
}