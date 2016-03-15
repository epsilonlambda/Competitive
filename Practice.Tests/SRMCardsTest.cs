using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpsilonLambda.Competitive.TopCoder.Practice;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class SRMCardsTest
    {
        SRMCards srmCards;

        [TestInitialize]
        public void TestSetup()
        {
            srmCards = new SRMCards();
        }

        private void AssertSolution(int expected, params int[] cards)
        {
            Assert.AreEqual(expected, srmCards.maxCards(cards));
        }

        private static int[] R(params int[] integers)
        {
            return integers;
        }

        private Action<int, int[]> AssertGroupOf(params int[] expectedGroup)
        {
            var expectedGroupCopy = expectedGroup.Clone() as int[];
            return (int card, int[] cards) =>
            {
                AssertGroupOfResult(expectedGroupCopy, card, cards);
            };
        }

        private void AssertGroupOfResult(int[] expectedGroup, int card, int[] cards)
        {
            var result = new HashSet<int>(srmCards.GroupOf(card, new HashSet<int>(cards)));
            foreach (int expected in expectedGroup)
            {
                Assert.IsTrue(result.Contains(expected));
            }
            Assert.AreEqual(expectedGroup.Length, result.Count);
        }

        [TestMethod]
        public void TestMethod1()
        {
            AssertSolution(0);
            AssertSolution(1, 1);
            AssertSolution(1, 2);
        }

        private readonly int[] Test1 = R(301, 302, 305, 307, 308, 309);
        [TestMethod]
        public void GroupOfTest()
        {
            AssertGroupOf(301)(301, R(301));
            AssertGroupOf(301, 302)(301, Test1);
            AssertGroupOf(305)(305, Test1);
            AssertGroupOf(301, 302)(302, Test1);
            AssertGroupOf(307, 308)(307, Test1);
            AssertGroupOf(307, 308, 309)(308, Test1);
            AssertGroupOf(308, 309)(309, Test1);
        }
    }

}
