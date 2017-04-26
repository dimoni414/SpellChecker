using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleBlank.Services
{
    public static class BaseDictionary
    {
        private static SortedDictionary<string, int> LoadDictionary()
        {
            var loader = new BinaryFormatter();
            using (var fstream = new FileStream("sortedDictionary.data"
                                                        , FileMode.Open, FileAccess.Read))
            {
                var loadingArray = loader.Deserialize(fstream) as Array;
                var result = new SortedDictionary<string, int>();
                foreach (string word in loadingArray)
                {
                    result.Add(word, 1);
                }
                return result;
            }
        }

        public static SortedDictionary<string, int> _dictionary = LoadDictionary();
    }
}