using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CapstoneTests
{
    [TestClass]
    public class UserInterfaceTests
    {
        UserInterface testObj;

        [TestInitialize]
        public void Init()
        {
            testObj = new UserInterface();
        }

        [DataTestMethod]
        [DataRow("1.5", 0)]
        [DataRow("0", 0)]
        [DataRow("20", 20)]
        [DataRow("1500", 1500)]
        [DataRow("5000", 5000)]
        [DataRow("-1000", 0)]
        [DataRow("7500", 0)]
        [DataRow("Matt is the JavaMan", 0)]
        public void TestAddMoneyFunctionality (string input, int expectedResult)
        {
            // ----Act---------------------------------------------- 
            int result = testObj.AddMoney(input);
            //----Assert--------------------------------------------
            Assert.AreEqual(expectedResult, result);
        }

        //"Please enter integer between 0 & 5000(inclusive)"




    }
}
