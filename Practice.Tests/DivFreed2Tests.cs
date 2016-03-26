using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsilonLambda.Competitive.TopCoder.Practice.Tests
{
    /// <summary>
    /// Summary description for DivFreed2Tests
    /// </summary>
    [TestClass]
    public class DivFreed2Tests
    {
        public DivFreed2Tests()
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

        DivFreed2 divFreed2;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            divFreed2 = new DivFreed2();
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
            Assert.AreEqual(3, divFreed2.count(2, 2));
        }

        [TestMethod]
        public void Ex1()
        {
            Assert.AreEqual(1, divFreed2.count(9, 1));
        }

        [TestMethod]
        public void Ex2()
        {
            Assert.AreEqual(15, divFreed2.count(3, 3));
        }

        [TestMethod]
        public void Ex3()
        {
            Assert.AreEqual(107, divFreed2.count(1, 107));
        }

        [TestMethod]
        public void Ex4()
        {
            Assert.AreEqual(83, divFreed2.count(2, 10));
        }

        [TestMethod]
        public void Ex5()
        {
            Assert.AreEqual(1515011, divFreed2.count(2, 1234));
        }

        [TestMethod]
        public void Ex6()
        {
            Assert.AreEqual(326, divFreed2.count(3, 8));
        }

        [TestMethod]
        public void Ex7()
        {
            Assert.AreEqual(526882214, divFreed2.count(10, 100000));
        }
    }
}
