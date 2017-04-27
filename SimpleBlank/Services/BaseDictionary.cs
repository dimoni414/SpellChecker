using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleBlank.Services
{
    public static class BaseDictionary
    {
        static BaseDictionary()
        {
            nameDictionary = "sortedDictionary.data";
            dictionary = DezerializeDictionary();
        }

        private static SortedDictionary<string, int> DezerializeDictionary()
        {
            if (!File.Exists(nameDictionary))
            {
                return new SortedDictionary<string, int>();
            }

            var loader = new BinaryFormatter();
            using (var fstream = new FileStream(nameDictionary, FileMode.Open, FileAccess.Read))
            {
                var result = (loader.Deserialize(fstream) as SortedDictionary<string, int>);
                if (result == null)
                {
                    return new SortedDictionary<string, int>();
                }
                return result;
            }
        }

        public static void SerializeDictionary()
        {
            using (var fStream = new FileStream(nameDictionary, FileMode.OpenOrCreate, FileAccess.Write))
            {
                new BinaryFormatter().Serialize(fStream, dictionary);
            }
        }

        public static SortedDictionary<string, int> dictionary;
        public static string nameDictionary;
    }
}