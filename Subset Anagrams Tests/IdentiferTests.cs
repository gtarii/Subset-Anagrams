using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Subset_Anagrams;

namespace Subset_Anagrams_Tests
{
    [TestClass]
    public class IdentiferTests
    {
        private const int numberOfPrimesTested = 10;
        private static readonly int[] firstTenPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }; // First 10 primes
        private static readonly char[] testCharacters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' }; // character placements in english alphabet: s-19th, h-8th, e-5th, p-16th
        private Identifier identifier = new Identifier();

        [TestMethod]
        // Test the GetPrimeProductVal method from the Identifier Class
        public void Test_GetPrimeProductVal()
        {
            var expectedPrimeProduct = 1; // calculate our expected prime product by taking the product of our array of test primes
            foreach (int p in firstTenPrimes)
            {
                expectedPrimeProduct *= p;
            }
            var primeProduct = identifier.GetProductPrimeValue(testCharacters);
            Assert.AreEqual(expectedPrimeProduct, primeProduct);
        }

        [TestMethod]
        // Test the GenerateAlphabetPrimeDictionary method from the Identifier Class
        public void TestVal_GenerateAlphabetPrimeDictionary()
        {
            var testDict = Identifier.GenerateAlphabetPrimeDictionary();
            var test_keys = testCharacters;

            // we test the generated dictionary by giving it keys and summing the values returned. We compare this sum to the expected sum.
            int test_sum = 0;
            foreach (char key in test_keys)
            {
                test_sum += testDict[key];
            }
            var expected_sum = 0; // expected sum is the sum of our prime array
            foreach (int p in firstTenPrimes)
            {
                expected_sum += p;
            }
            Assert.AreEqual(expected_sum, test_sum);
        }

        [TestMethod]
        // Test the GeneratePrimes method from the Identifier Class
        public void Test_GeneratePrimes()
        {
            var expected = firstTenPrimes;
            var primeArray = Identifier.GeneratePrimes(numberOfPrimesTested);
            CollectionAssert.AreEqual(expected, primeArray);
        }
    }
}

