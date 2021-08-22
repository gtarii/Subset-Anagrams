using System;
using System.Collections.Generic;

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

            String[] dictionary = ReadFromFileLSV(@fileLocation);
        }



        // Method that reads a .txt file containing a dictionary of words in line separated value (LSV) format and stores this data in an array.
        private static string[] ReadFromFileLSV(string fileLocation)
        {
            return System.IO.File.ReadAllLines(@fileLocation);
        }


        // Method to merge an array of words and an equal length array of integers together

    }
}
