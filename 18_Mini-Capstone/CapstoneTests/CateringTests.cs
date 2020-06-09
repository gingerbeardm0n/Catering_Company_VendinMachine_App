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

        //AddMoney tests

        [TestMethod]
        public void AddMoneyTest()
        {
            //Arrange
            Catering moneyTest = new Catering();

            //Act
            string result = moneyTest.AddMoney("500");

            //Assert
           Assert.AreEqual(result, "Your account balance is: $500");
        }



        //PurchaseIndividualItem tests

        [TestMethod]
        public void IndividualPurchaseTest()
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
        public void IndividualPurchaseTestProductCodeNotFound()
        {
            //Arrange
            Catering purchaseTest = new Catering();

            //Act
            string result = purchaseTest.PurchaseIndividualItem("Z3", 10);

            //Assert
            Assert.AreEqual(result, "PRODUCT CODE NOT FOUND");
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
        public void CalculateChangeTest()
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
