using System;
using System.Collections.Generic;
using System.Text;

namespace Subset_Anagrams
{
    // Objective of this program is recieve user input of a string comprised of letters and return all anagrams of the subset of letters
    class Program
    {
        public static void Main()
        {
            ProcessPartA ppa = new ProcessPartA();

            //our program loop for requesting user input and returning valid subset anagrams
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ESC to stop process!");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                ppa.InteractWithUser();
            }
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
