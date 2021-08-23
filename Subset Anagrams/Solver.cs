using System;
using System.Collections.Generic;
using System.Linq;

// Objective of this program is recieve user input of a string comprised of letters and return all anagrams of the subset of letters
namespace Subset_Anagrams
{
    // The Solver class is the primary class of the program.
    class Solver
    {
        public static void Main(string[] args)
        {
            // create an instance of our identifer class
            var identifer = new Identifier();

            // set up variables
            string fileLocation = @"C:\Users\ariho\VisualStudio\source\repos\Subset Anagrams\data\wordlist.10000.txt";
            String[] wordDictionary = ReadFromFileLSV(@fileLocation);

            // create a dictionary of word-value pairs the words from the wordDictionary and prime-product values from the identifier class
            var wordValuePairs = CreateWordValuePairs(wordDictionary, identifer);

            //our program loop for requesting user input and returning valid subset anagrams
            int max_iterations = 1000;
            int current_iteration = 0;
            while (current_iteration < max_iterations) { // This needs a proper condition
                current_iteration++;
                
                // Get user input
                var input = GetInput();
                var inputValue = identifer.GetProductPrimeValue(input);

                //get subset anagrams of user input
                var validAnagrams = FindAnagrams(inputValue, wordValuePairs);

                // return list of valid anagrams to user, within reason, could for instance see first 10,20 etc etc
                foreach (string anagram in validAnagrams)
                {
                    Console.WriteLine(anagram);
                }
            }
        }

        // Method for finding and returning subset anagrams of a list of characters from within a list of words
        public static List<string> FindAnagrams(int valueOfInputString, Dictionary<string, int> wordValuePairs)
        {
            // !!! if the value of a word in our dictionary divides into the value of our input, then it is a subset anagram and we add it to a list of words to return
            var outputWords = new List<string>();
            foreach (var wordValuePair in wordValuePairs)
            {
                var word = wordValuePair.Key;
                var value = wordValuePair.Value;
                if (valueOfInputString % value == 0)
                {
                    outputWords.Add(word);
                }
            }
            return outputWords;
        }


        // Method for requesting a set of characters from the user. We clean whitespace, uncapitalise all and remove non alphabetical characters
        public static char[] GetInput()
        {
            // explain rules for input to user
            String inputRulesString = "please input a word or some letters, no numbers or special characters";
            Console.WriteLine(inputRulesString);

            // get user input as string
            var input = Console.ReadLine();

            // get only desired characters from input, i.e. no whitespace or special characters
            var onlyLetters = new String(input.Where(Char.IsLetter).ToArray());
            return onlyLetters.ToCharArray();
        }


        // Method that reads a .txt file containing a dictionary of words in line separated value (LSV) format and stores this data in an array.
        public static string[] ReadFromFileLSV(string fileLocation)
        {
            return System.IO.File.ReadAllLines(@fileLocation);
        }


        // Method to create a dictionary given valid words and their product-prime values
        public static Dictionary<string, int> CreateWordValuePairs(string[] words, Identifier identifier)
        {
            var wordValuePairs = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int wordValue = identifier.GetProductPrimeValue(word.ToCharArray());
                wordValuePairs.Add(word, wordValue);
            }

            return wordValuePairs;
        }
    }
}
