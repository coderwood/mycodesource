using EasyCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasyUtility_Tests
{


    /// <summary>
    ///This is a test class for AlgorithmUtilityTest and is intended
    ///to contain all AlgorithmUtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AlgorithmUtilityTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for BubbleSort
        ///</summary>
        [TestMethod()]
        public void BubbleSortTest()
        {
            int[] inputArray = { 3, 5, 1, 9, 2 };
            int[] expected = { 1, 2, 3, 5, 9 };
            int[] actual;
            actual = AlgorithmUtility.BubbleSort(inputArray);
            CollectionAssert.Equals(expected, actual);
        }

        /// <summary>
        ///A test for Foo
        ///</summary>
        [TestMethod()]
        public void FooTest()
        {
            int num = 0;
            int expected = 0;
            int actual;
            actual = AlgorithmUtility.Foo(num);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Swap
        ///</summary>
        [TestMethod()]
        public void SwapTest()
        {
            int i = 3;
            int iExpected = 5;
            int j = 5;
            int jExpected = 3;
            AlgorithmUtility.Swap(ref i, ref j);
            Assert.AreEqual(iExpected, i);
            Assert.AreEqual(jExpected, j);
        }
    }
}
