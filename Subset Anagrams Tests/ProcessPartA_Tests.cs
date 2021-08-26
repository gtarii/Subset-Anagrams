using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Subset_Anagrams;

namespace Subset_Anagrams_Tests
{
    [TestClass]
    public class ProcessPartA_Tests
    {
        // testing variables
        Identifier identifier = new Identifier();
        string[] testWords = new string[] {"abc", "sheep", "toothbrush"};


        [TestMethod]
        //
        public void Test_Main()
        {

        }
        
        [TestMethod]
        //
        public void Test_FindAnagrams()
        {

        }

        [TestMethod]
        //
        public void Test_GetInput()
        {

        }

        [TestMethod]
        //
        public void Test_ReadFromFileLSV()
        {

        }

        [TestMethod]
        //
        public void Test_CreateWordValuePairs()
        {
            var pairs = ProcessPartA.CreateWordValuePairs(testWords, identifier);
            var testKey = testWords[0];
            var testValue = pairs[testKey];
            var expectedValue = identifier.GetProductPrimeValueOfWord(testKey);
            Assert.AreEqual(expectedValue, testValue);
        }
    }
}
