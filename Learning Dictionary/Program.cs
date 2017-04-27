//using Microsoft.Win32;
//using System;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Learning_Dictionary
//{
//    internal class Program
//    {
//        [STAThread]
//        private static void Main(string[] args)
//        {
//            var fileName = "";
//            var fileDilog = new OpenFileDialog();
//            if (fileDilog.ShowDialog() == true)
//            {
//                fileName = fileDilog.FileName;
//            }

//            string allText;
//            using (var streamReader = new StreamReader(fileName, Encoding.Default))
//            {
//                allText = streamReader.ReadToEnd();
//            }

//            allText = allText.Replace('\n', ' ');

//            var stringBuilder = new StringBuilder(100000);
//            var rightSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
//            //var rightSymbols = @"[а-я]"+" ";

//            foreach (var letter in allText)
//            {
//                var letter2 = char.ToLower(letter);

//                if (rightSymbols.Contains(letter2))
//                {
//                    stringBuilder.Append(letter2);
//                }
//            }

//            var list = Regex.Replace(stringBuilder.ToString(), @"\s+", " ").Split(' ');
//            var shortList = list.Distinct();

//            //var sortedItems = from words in shortList
//            //                  orderby words
//            //                  select words;
//            //var sortedArray = sortedItems.ToArray();

//            var binaryFormatter = new BinaryFormatter();

//            var nameDictionary = "sortedDictionary.data";

//            using (var fStream = new FileStream(nameDictionary
//                    , FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
//            {
                
//                if (new FileInfo(nameDictionary).Length > 0)
//                {
//                    oldDictionary= binaryFormatter.Deserialize(fStream) as Array;
//                }
//                shortList.ToList().AddRange(oldDictionary);
//                    .Serialize(fStream, sortedArray);
//            }
//        }
//    }
//}

////string fileContent = File.ReadAllText("big.txt");
////List<string> wordList = fileContent.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

////            foreach (var word in wordList)
////            {
////                string trimmedWord = word.Trim().ToLower();
////                if (_wordRegex.IsMatch(trimmedWord))
////                {
////                    if (_dictionary.ContainsKey(trimmedWord))
////                        _dictionary[trimmedWord]++;
////                    else
////                        _dictionary.Add(trimmedWord, 1);
////                }
////            }