using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsilonLambda.Competitive.TopCoder.Practice.Tests
{
    /// <summary>
    /// Summary description for MoveStonesEasyTest
    /// </summary>
    [TestClass]
    public class MoveStonesEasyTest
    {
        public MoveStonesEasyTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        MoveStonesEasy moveStonesEasy;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            moveStonesEasy = new MoveStonesEasy();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Ex0()
        {
            Assert.AreEqual(1, moveStonesEasy.get(new int[] { 1, 2 }, new int[] { 2, 1 }));
        }
        [TestMethod]
        public void Ex1()
        {
            Assert.AreEqual(10, moveStonesEasy.get(new int[] { 10, 0 }, new int[] { 0, 10 }));
        }
        [TestMethod]
        public void Ex2()
        {
            Assert.AreEqual(2, moveStonesEasy.get(new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 }));
        }
        [TestMethod]
        public void Ex3()
        {
            Assert.AreEqual(0, moveStonesEasy.get(new int[] { 12, 12 }, new int[] { 12, 12 }));
        }
        [TestMethod]
        public void Ex4()
        {
            Assert.AreEqual(-1, moveStonesEasy.get(new int[] { 5 }, new int[] { 6 }));
        }
        [TestMethod]
        public void Ex5()
        {
            Assert.AreEqual(9, moveStonesEasy.get(new int[] { 3, 10, 0, 4, 0, 0, 0, 1, 0 }, new int[] { 5, 5, 0, 7, 0, 0, 0, 0, 1 }));
        }
    }
}
