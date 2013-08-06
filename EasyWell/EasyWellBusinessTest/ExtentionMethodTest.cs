using EasyUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasyWellBusinessTest
{
    /// <summary>
    ///This is a test class for ExtentionMethodTest and is intended
    ///to contain all ExtentionMethodTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtentionMethodTest
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
        ///A test for NextEnum
        ///</summary>
        public void NextEnumTestHelper<T>()
            where T : struct
        {
            Random random = new Random();
            T expected =new T();
            T actual;
            actual = ExtentionMethod.NextEnum<T>(random);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NextEnumTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call NextEnumTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for NextBool
        ///</summary>
        [TestMethod()]
        public void NextBoolTest()
        {
            Random random = new Random();
            bool actual;
            int countAll = 10000;
            int countTrue = 0;
            int countFalse = 0;
            for (int i = 0; i < countAll; i++)
            {
                actual = ExtentionMethod.NextBool(random);
                if (actual)
                    countTrue++;
                else
                    countFalse++;
            }
            Assert.IsTrue(countAll == (countFalse + countTrue));
            Assert.IsTrue(countFalse > 0.9 * countTrue || countTrue > 0.9 * countFalse);
        }
    }
}
