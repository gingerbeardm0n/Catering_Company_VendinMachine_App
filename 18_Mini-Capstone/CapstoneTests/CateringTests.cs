using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTests
    {

        //---------- AddMoney Tests --------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void AddMoney_BaseCaseTest()
        {
            //Arrange
            Catering moneyTest = new Catering();

            //Act
            string result = moneyTest.AddMoney("500");

            //Assert
            Assert.AreEqual(result, "Your account balance is: $500");
        }

        [TestMethod]
        public void AddMoney_OutOfSpecifiedRangeTest()
        {
            //Arrange
            Catering moneyTest = new Catering();

            //Act
            string result1 = moneyTest.AddMoney("7777");
            string result2 = moneyTest.AddMoney("-42");

            //Assert
            Assert.AreEqual(result1, "Balance must be between 0 and $5000");
            Assert.AreEqual(result2, "Balance must be between 0 and $5000");
        }

        [TestMethod]
        public void AddMoney_EdgeCaseTest()
        {
            //Arrange
            Catering moneyTest = new Catering();

            //Act
            string result1 = moneyTest.AddMoney("0");
            string result2 = moneyTest.AddMoney("5000");

            //Assert
            Assert.AreEqual(result1, "Your account balance is: $0");
            Assert.AreEqual(result2, "Your account balance is: $5000");
        }

        [TestMethod]
        public void AddMoney_NotEnteringAnIntegerTest()
        {
            //Arrange
            Catering moneyTest = new Catering();

            //Act
            string result = moneyTest.AddMoney("twenty five");
            string result2 = moneyTest.AddMoney("");

            //Assert
            Assert.AreEqual(result, "You must enter an integer");
            Assert.AreEqual(result2, "You must enter an integer");
        }



        //---------- PurchaseIndividualItem Tests ------------------------------------------------------------------------------------------

        [TestMethod]
        public void IndividualPurchase_ItemAddedToCartTest()
        {
            //Arrange
            Catering purchaseTest = new Catering();
            purchaseTest.AddMoney("500");
            //Act
            string result = purchaseTest.PurchaseIndividualItem("B3", 10);

            //Assert
            Assert.AreEqual(result, "ITEM ADDED TO CART");
        }

        [TestMethod]
        public void IndividualPurchase_ProductCodeNotFoundTest()
        {
            //Arrange
            Catering purchaseTest = new Catering();

            //Act
            string result = purchaseTest.PurchaseIndividualItem("Z3", 10);

            //Assert
            Assert.AreEqual(result, "PRODUCT CODE NOT FOUND");
        }

        [TestMethod] //NEED TO ASK A QUESTION ABOUT THIS ONE
        public void IndividualPurchase_SoldOutTest()
        {
            //Arrange
            Catering purchaseTest = new Catering();
            CateringItem testItem = new CateringItem();
            testItem.QuantityRemaining = 0;

            //Act
            string result = purchaseTest.PurchaseIndividualItem("B3", 25);

            //Assert
            Assert.AreEqual(result, "SOLD OUT");
        }

        [TestMethod] // GOING TO HAVE THE SAME PROBLEM AS SOLD OUT TEST
        public void IndividualPurchase_InsuffucientStockTest()
        {
            //Arrange
            Catering purchaseTest = new Catering();

            //Act
            string result = purchaseTest.PurchaseIndividualItem("B3", 10);

            //Assert
            Assert.AreEqual(result, "PRODUCT CODE NOT FOUND");
        }

        [TestMethod] // GOING TO HAVE THE SAME PROBLEM AS SOLD OUT TEST
        public void IndividualPurchase_InsuffucientFundsTest()
        {
            //Arrange
            Catering purchaseTest = new Catering();


            //Act
            string result = purchaseTest.PurchaseIndividualItem("B1", 20);

            //Assert
            Assert.AreEqual(result, "INSUFFICIENT FUNDS");
        }


        //PrintPurchases tests

        [TestMethod]
        public void PrintPurchasesTest()
        {
            //Arrange
            Catering printTest = new Catering();
            CateringItem testItem = new CateringItem();

            List<CateringItem> testList = printTest.PurchasedItems;


            testItem.IntQuantityDesired = 10;
            testItem.Type = "D";
            testItem.Name = "Cake";
            testItem.Price = (decimal)1.80;

            testList.Add(testItem);

            string compareResult = testItem.IntQuantityDesired.ToString().PadRight(2) + "                " + testItem.Type.PadRight(4) +
                    "   " + testItem.Name.PadRight(20) + "   " + "$" + testItem.Price.ToString().PadRight(2) + "   " +
                    "$" + (testItem.IntQuantityDesired * testItem.Price).ToString().PadRight(2) + "\n";


            //Act
            string result = printTest.PrintPurchases(testList);

            //Assert
            Assert.AreEqual(result, compareResult);

        }





        //CalculateChange tests

        [TestMethod]
        public void CalculateChangeTest_1()
        {
            //Arrange
            Catering changeTest = new Catering();
            List<int> result = new List<int>();
            List<int> compareList = new List<int>();

            compareList.Add(1);
            compareList.Add(0);
            compareList.Add(0);
            compareList.Add(0);
            compareList.Add(0);
            compareList.Add(0);
            compareList.Add(0);

            //Act
            result = changeTest.CalculateChange(20);

            //Assert
            CollectionAssert.AreEqual(result, compareList);
        }

        [TestMethod]
        public void CalculateChangeTest_2()
        {
            //Arrange
            Catering changeTest = new Catering();
            List<int> result = new List<int>();
            List<int> compareList = new List<int>();

            compareList.Add(18);
            compareList.Add(0);
            compareList.Add(1);
            compareList.Add(3);
            compareList.Add(1);
            compareList.Add(2);
            compareList.Add(0);

            //Act
            result = changeTest.CalculateChange(368.45M);

            //Assert
            CollectionAssert.AreEqual(result, compareList);
        }

        [TestMethod]
        public void CalculateChangeTest_3()
        {
            //Arrange
            Catering changeTest = new Catering();
            List<int> result = new List<int>();
            List<int> compareList = new List<int>();

            compareList.Add(2);
            compareList.Add(0);
            compareList.Add(0);
            compareList.Add(2);
            compareList.Add(3);
            compareList.Add(1);
            compareList.Add(1);

            //Act
            result = changeTest.CalculateChange(42.90M);

            //Assert
            CollectionAssert.AreEqual(result, compareList);
        }

        [TestMethod]
        public void CalculateChangeTest_4()
        {
            //Arrange
            Catering changeTest = new Catering();
            List<int> result = new List<int>();
            List<int> compareList = new List<int>();

            compareList.Add(128);
            compareList.Add(1);
            compareList.Add(1);
            compareList.Add(4);
            compareList.Add(1);
            compareList.Add(1);
            compareList.Add(0);

            //Act
            result = changeTest.CalculateChange(2579.35M);

            //Assert
            CollectionAssert.AreEqual(result, compareList);
        }

        [TestMethod]
        public void CalculateChangeTest_5()
        {
            //Arrange
            Catering changeTest = new Catering();
            List<int> result = new List<int>();
            List<int> compareList = new List<int>();

            compareList.Add(61);
            compareList.Add(1);
            compareList.Add(0);
            compareList.Add(4);
            compareList.Add(2);
            compareList.Add(0);
            compareList.Add(0);

            //Act
            result = changeTest.CalculateChange(1234.50M);

            //Assert
            CollectionAssert.AreEqual(result, compareList);
        }


        //BalanceToZero tests

        [TestMethod]
        public void BalanceToZeroTest()
        {
            //Arrange
            Catering zeroTest = new Catering();

            //Act
            string result = zeroTest.BalanceToZero();

            //Assert
            Assert.AreEqual(result, "Your change has been returned and your balance is $0. Thank you!");
        }




        //UpdateBalance tests

        [TestMethod]
        public void UpdateBalanceTest()
        {
            //Arrange
            Catering balanceTest = new Catering();
            CateringItem testItem = new CateringItem();

            balanceTest.AddMoney("500");

            testItem.Price = (decimal)1.50;

            //Act
            balanceTest.UpdateBalance(testItem, 20);

            //Assert
            Assert.AreEqual(balanceTest.Balance, 470);
        }





    }
}
