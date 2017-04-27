using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleBlank.Services
{
    internal class LearningDictionaryService
    {
        public void LearnByBook()
        {
            AddWordsToDictionary(
                        GetParticularWord(
                                     GetAllTextFromFile(
                                                      GetFileName())));
        }

        private string GetFileName()
        {
            var fileDilog = new OpenFileDialog();
            fileDilog.Filter = "Text files(*.txt)|*.txt";
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

            dirtyText = dirtyText.ToLower();

            var stringBuilder = new StringBuilder(100000);

            foreach (var letter in textWithoutNewLine)
            {
                if (Alphabet.Contains(letter))
                {
                    stringBuilder.Append(letter);
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
                if (BaseDictionary.dictionary.ContainsKey(word))
                {
                    BaseDictionary.dictionary[word]++;
                }
                else
                {
                    BaseDictionary.dictionary.Add(word, 1);
                }
            }
        }
    }
}