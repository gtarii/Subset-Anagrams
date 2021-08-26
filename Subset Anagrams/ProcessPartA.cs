using System;
using System.Collections.Generic;
using System.Linq;


namespace Subset_Anagrams
{

    public class ProcessPartA
    {
        // initialise variables
        private readonly string fileLocation;
        private readonly string[] wordDictionary;
        private readonly Identifier identifer;
        private readonly Dictionary<string, int> wordValuePairs;

        public ProcessPartA()
        {
            // set up variables
            fileLocation = @"C:\Users\ariho\VisualStudio\source\repos\Subset Anagrams\data\1000 most common english words\1-1000.txt";
            wordDictionary = ReadFromFileLSV(@fileLocation);
            identifer = new Identifier();

            // create a dictionary of word-value pairs the words from the wordDictionary and prime-product values from the identifier class
            wordValuePairs = CreateWordValuePairs(wordDictionary, identifer);
        }


        public void InteractWithUser()
        {
            // Get user input
            var input = ReadInput();
            var inputValue = identifer.GetProductPrimeValueOfWord(input);

            //get subset anagrams of user input
            var validAnagrams = FindAnagrams(inputValue, wordValuePairs);
            WriteOutput(validAnagrams);
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
        public static string ReadInput()
        {
            // explain rules for input to user
            Console.ForegroundColor = ConsoleColor.White;
            string inputRulesString = "\nPlease input a word or some letters to form an anagram, numbers or special characters will be ignored";
            Console.WriteLine(inputRulesString);

            // get user input as string
            Console.ForegroundColor = ConsoleColor.Green;
            var input = Console.ReadLine();

            // get only desired characters from input, i.e. no whitespace or special characters
            var onlyLetters = new String(input.Where(Char.IsLetter).ToArray());
            return onlyLetters;
        }


        //Method that writes to the console the output. 
        public static void WriteOutput(List<string> outputList)
        {
            int anagramCount = outputList.Count;
            int resultsPerPage = 10;
            int pageCount = ((anagramCount - 1) / resultsPerPage) + 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{anagramCount} Subset anagram(s) found");

            for (int i = 0; i < anagramCount; i++)
            {
                if (i % resultsPerPage == 0) //new page output
                {
                    Console.WriteLine($"(Page { (i / resultsPerPage) + 1 } of {pageCount})");
                }

                Console.WriteLine(outputList[i]);

                if (i != anagramCount && i % resultsPerPage == resultsPerPage - 1) // end of page interaction, ask if user wants to proceed to next page or not
                {
                    Console.WriteLine("Next page? (Y) or New word (N)");
                    ConsoleKeyInfo keyInfo;

                    bool isUndecided = true;
                    while (isUndecided == true)
                    {
                        keyInfo = Console.ReadKey(true);
                        string decisionKey = keyInfo.KeyChar.ToString().ToLower();
                        if (decisionKey == "y") { break; } // method continues with listing anagrams
                        if (decisionKey == "n") { return; } // stops output and user and input a new word
                    }

                }

            }
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
                int wordValue = identifier.GetProductPrimeValueOfWord(word);
                wordValuePairs.Add(word, wordValue);
            }

            return wordValuePairs;
        }
    }
}
