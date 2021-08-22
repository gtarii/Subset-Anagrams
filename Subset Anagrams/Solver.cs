using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

// Objective of this program is recieve user input of a string comprised of letters and return all anagrams of the subset of letters
namespace Subset_Anagrams
{
    // The Solver class is the primary class of the program.
    class Solver
    {
        public static void Main(string[] args)
        {
            // set up variables
            string fileLocation = @"C:\Users\ariho\VisualStudio\source\repos\Subset Anagrams\data\wordlist.10000.txt";
            String[] wordDictionary = ReadFromFileLSV(@fileLocation);

            // create an instance of our identifer class
            var identifer = new Identifier();

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


        // Method to merge an array of words and an equal length array of integers together

    }
}
