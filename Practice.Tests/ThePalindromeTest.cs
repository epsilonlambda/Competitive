using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsilonLambda.Competitive.TopCoder.Practice.Tests
{
    [TestClass]
    public class ThePalindromeTest
    {
        ThePalindrome thePalindrome;

        [TestInitialize]
        public void SetupTest()
        {
            thePalindrome = new ThePalindrome();
        }

        [TestMethod]
        public void MaxPalindromeSuffix_Regular()
        {
            Assert.AreEqual("bab", thePalindrome.FindMaxPalindromeSuffix("abab"));
        }

        [TestMethod]
        public void MaxPalindromeSuffix_Edge()
        { 
            Assert.AreEqual("y", thePalindrome.FindMaxPalindromeSuffix("qwerty"));
            Assert.AreEqual("", thePalindrome.FindMaxPalindromeSuffix(""));
            Assert.AreEqual("abacaba", thePalindrome.FindMaxPalindromeSuffix("abacaba"));
        }

        [TestMethod]
        public void Ex0()
        {
            Assert.AreEqual(5, thePalindrome.find("abab"));
        }

        [TestMethod]
        public void Ex1()
        {
            Assert.AreEqual(7, thePalindrome.find("abacaba"));
        }

        [TestMethod]
        public void Ex2()
        {
            Assert.AreEqual(11, thePalindrome.find("qwerty"));
        }

        [TestMethod]
        public void Ex3()
        {
            Assert.AreEqual(38, thePalindrome.find("abdfhdyrbdbsdfghjkllkjhgfds"));

        }
    }
}
