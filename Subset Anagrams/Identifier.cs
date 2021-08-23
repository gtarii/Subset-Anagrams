using System;
using System.Collections.Generic;
using System.Text;

namespace Subset_Anagrams
{
    public class Identifier
    {
        private static Dictionary<char, int> alphabetPrimeDict;


        // Initialise Identifier class with a alphabet-prime dictionary
        public Identifier()
        {
            alphabetPrimeDict = GenerateAlphabetPrimeDictionary();
        }
        


        // Method that uses the alphabet-prime dictionary to return the product of the primes associated with the input characters
        public int GetProductPrimeValue(char[] characters)
        {
            int product = 1; // this will be the variable we return equal to the product of the primes associated with each of its characters
            foreach (char c in characters)
            {
                product *= alphabetPrimeDict[c];
            }
            
            return product;
        }
        
        // Method that generates a dictionary with keys being the 26 characters of the english alphabet, and their corresponding values being the first available prime available for assignment
        public static Dictionary<char, int> GenerateAlphabetPrimeDictionary()
        {
            char[] alphabet = new char[] {
                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z'};

            // get the corresponding primes for each character
            int[] primes = GeneratePrimes(alphabet.Length);

            // put the alphabet characters and their primes into a dictionary
            var primeDict = new Dictionary<char, int>();
            for (int index = 0; index < alphabet.Length; index++)
            {
                primeDict.Add(alphabet[index], primes[index]);
            }
            return primeDict;
        }

        // generate the first n primes
        public static int[] GeneratePrimes(int numberOfPrimes)
        {
            // initialise array for the primes
            int[] arrayOfPrimes = new int[numberOfPrimes];

            // our first prime is 2 so we simply add it to the start of our primes array, this also means we start adding primes at index 1 instead of 0.
            arrayOfPrimes[0] = 2;
            // we find primes by using a "sieve". The first prime to add is 2, beyond this we check a new number equal to the last prime added plus 1.
            // To check a number we see if any previous prime divides into it. If not, our new number is prime and we add it to the array.
            // Else, our new number is not prime, so we increment 1 and try again.
            for (int index = 1; index < numberOfPrimes; index++)
            {
                int numberToCheck = arrayOfPrimes[index - 1] + 1;
                bool factorFound; // this will be our flag to break the while loop, if we ever find a factor, i,e not a prime this is set to true and the loop repeats until we dont find a factor.

                while (true) //repeat our check loop whilst incrementing our number to check until we have a new prime
                {
                    factorFound = false; // reset our break flag with each iteration of the while loop
                    
                    //check if our new number is divisible by any previous primes found in our array.
                    foreach (int prime in arrayOfPrimes)
                    {
                        if (prime > 1 && numberToCheck % prime == 0) // not prime
                        {
                            factorFound = true;
                            numberToCheck++; // increment our number
                            break; //break the checking loop so we can try our new incremented number
                        }
                    }
                    //if we havent found any factors then our number is prime and we can break the while loop
                    if (factorFound == false)
                    {
                        arrayOfPrimes[index] = numberToCheck;
                        break;
                    }
                }
            }
            return arrayOfPrimes;
        }
    }
}
