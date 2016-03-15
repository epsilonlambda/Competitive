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
            Assert.AreEqual(expected, srmCards.maxTurns(cards));
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
            var cardsLinkedList = new LinkedList<int>(cards);
            var cardNode = cardsLinkedList.Find(card);
            var result = new HashSet<int>(SRMCards.GetCardGroup(cardNode).Select(n => n.Value));
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

        [TestMethod]
        public void Ex0()
        {
            AssertSolution(1, 498, 499);
        }

        [TestMethod]
        public void Ex1()
        {
            AssertSolution(4, 491, 492, 495, 497, 498, 499);
        }

        [TestMethod]
        public void Ex2()
        {
            AssertSolution(4, 100, 200, 300, 400);
        }

        [TestMethod]
        public void Ex3()
        {
            AssertSolution(6, 11, 12, 102, 13, 100, 101, 99, 9, 8, 1);
        }

        [TestMethod]
        public void Ex4()
        {
            AssertSolution(4, 118, 321, 322, 119, 120, 320);
        }

        [TestMethod]
        public void Ex5()
        {
            AssertSolution(7, 10, 11, 12, 13, 14, 1, 2, 3, 4, 5, 6, 7, 8, 9);
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
