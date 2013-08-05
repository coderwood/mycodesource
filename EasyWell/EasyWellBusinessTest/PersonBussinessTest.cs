using EasyWellBusiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasyWellBusinessTest
{
    
    
    /// <summary>
    ///This is a test class for PersonBussinessTest and is intended
    ///to contain all PersonBussinessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonBussinessTest
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
        ///A test for GetRandomSex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EasyWellBusiness.dll")]
        public void GetRandomSexTest()
        {
            PersonBussiness_Accessor target = new PersonBussiness_Accessor(); // TODO: Initialize to an appropriate value
            string expected = "Male,Female,Unknown"; 
            string actual;
            for (int i = 0; i < 1000; i++)
            {
                actual = target.GetRandomSex();
                Assert.IsTrue(expected.IndexOf(actual) >= 0);
            }
        }
    }
}
