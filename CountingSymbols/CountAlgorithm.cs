using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSymbols
{
    internal static class CountAlgorithm
    {
        // Starts the algorithm
        internal static void Process(string textData, bool caseSensitive = true)
        {
            Dictionary<char, int> countedLettersDict = ReturnCounted(textData, caseSensitive);
            Dictionary<char, int> sortedCountedLettersDict = ReturnSorted(countedLettersDict);
            ToString(textData, sortedCountedLettersDict);
        }

        // Counts the occurrence of every digit, letter or special symbol in the given string
        private static Dictionary<char, int> ReturnCounted(string textData, bool caseSensitive)
        {
            Dictionary<char, int> countedLettersDict = new Dictionary<char, int>();

            foreach (char character in textData)  // e.g. word or message
            {
                // Normal symbol or converted to Uppercase --> which is depends on [caseSensitive] flag
                char characterToSave = caseSensitive ? character : Convert.ToChar(character.ToString().ToUpper());

                if (!countedLettersDict.ContainsKey(characterToSave))
                {
                    countedLettersDict.Add(characterToSave, 1);  // Add new symbol to dictionary and set it's occurrence as 1
                }
                else
                {
                    countedLettersDict.TryGetValue(characterToSave, out int value);
                    countedLettersDict[characterToSave] = value + 1;
                }
            }

            return countedLettersDict;
        }

        // Sorts dictionary KeyValuePair by the key (set higher priority to the lowercase letters)
        private static Dictionary<char, int> ReturnSorted(Dictionary<char, int> countedLettersDict)
        {
            // Uppercase letters has the higher priority, so there's a need to converting every letter to lowercase
            Dictionary<char, int> sortedCountedLettersDict = countedLettersDict.OrderBy(pair => pair.Key.ToString().
                ToLower()).ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedCountedLettersDict;
        }

        // Displays sorted and counted results as the vertical list of elements
        private static void ToString(string textData, Dictionary<char, int> sortedCountedLettersDict)
        {
            Console.WriteLine("Number of symbols in the text:");
            Console.WriteLine($"\"{textData}\"\n");
            foreach (KeyValuePair<char, int> pair in sortedCountedLettersDict)
            {
                Console.WriteLine($"  \"{pair.Key}\": {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}
