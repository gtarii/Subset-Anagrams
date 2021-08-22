using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Subset_Anagrams_Tests
{
    [TestClass]
    public class IdentiferTests
    {
        private const int numberOfPrimesTested = 10;
        private static readonly int[] firstTenPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }; // First 10 primes
        [TestMethod]
        public void Test_GeneratePrimes()
        {
            var expected = firstTenPrimes;
            var primeArray = Subset_Anagrams.Identifier.GeneratePrimes(numberOfPrimesTested);
            CollectionAssert.AreEqual(expected, primeArray);
        }
    }
}

