using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{


    public class Catering
    {
        CateringItem purchasedItem = new CateringItem();

        // make constructor that reads catering file and adds to list
        // This class should contain all the "work" for catering

        public decimal Balance { get; private set; }




        public decimal TotalCost { get; private set; }

        public List<CateringItem> PurchasedItems { get; } = new List<CateringItem>();


        public Catering(decimal balance, decimal totalCost)
        {
            Balance = balance;
            TotalCost = totalCost;
        }

        private List<CateringItem> items = new List<CateringItem>();

        public Catering()
        {
            items = ReadItems();
        }

        public CateringItem[] ItemList
        {
            get
            {
                return items.ToArray(); // Taking a list of objects (CateringItem) and putting into an array - why?
            }
        }


        private List<CateringItem> ReadItems()
        {
            FileAccess fa = new FileAccess();
            return fa.ReadItems();
        }

        //method

        //AddMoney Method


        public string AddMoney(string userInput) //log everytime money is added
        {
            int deposit = 0;
            try
            {
                deposit = int.Parse(userInput);

                if (deposit >= 0 && deposit + Balance <= 5000)

                {
                    Balance += deposit;
                }
                else
                {
                    return "Balance must be between 0 and $5000";
                }
            }
            catch (Exception)
            {
                return "You must enter an integer";
            }
            return "Your account balance is: " + "$" + Balance;

        }





        public string CheckProductCode(string productCode, int intQuantityDesired)
        {
            foreach (CateringItem itemObj in items)
            {

                if ((productCode == itemObj.Code) && (itemObj.QuantityRemaining >= intQuantityDesired) && ((intQuantityDesired * itemObj.Price) < Balance))
                {

                    purchasedItem.IntQuantityDesired = itemObj.IntQuantityDesired;
                    purchasedItem.Code = itemObj.Code;
                    purchasedItem.Name = itemObj.Name;
                    purchasedItem.Price = itemObj.Price;
                    purchasedItem.Type = itemObj.Type;

                    PurchasedItems.Add(purchasedItem);

                    return "Purchased!";
                }

                if (productCode == itemObj.Code)
                {

                    if (itemObj.QuantityRemaining == 0)
                    {
                        return "SOLD OUT";
                    }

                    if (itemObj.QuantityRemaining < intQuantityDesired)
                    {
                        return "INSUFFICIENT STOCK";
                    }

                    if (intQuantityDesired * itemObj.Price > Balance)
                    {
                        return "INSUFFICIENT FUNDS";
                    }
                }

            }

            return "Product code not found";

        }

        public void Purchase(int intQuantityDesired, decimal balance)
        {
            Balance -= (purchasedItem.Price * intQuantityDesired);
        
        }

        //public decimal UpdateTotalCost(int intQuantityDesired)
        //{
        //    foreach (CateringItem item in purchasedItems)
        //    {
        //        TotalCost += (item.Price * intQuantityDesired);
        //    }

        //    return TotalCost;
        //}

        public string PrintPurchases(List<CateringItem> purchasedItems)
        {
            string result = "";

            foreach (CateringItem item in purchasedItems)
            {
                result += item.IntQuantityDesired + "   " + item.Type + "   " + item.Name + "   " + "$" + item.Price + "   " + "$" + (item.IntQuantityDesired * item.Price) + "\n";
            }

            return result;
        }

        public string BalanceToZero()
        {
            Balance = 0;
            return "Your change has been returned and your balance is $0. Thank you!";
        }


        public string GiveChange(decimal balance)
        {
            decimal cashBack = balance;



            int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            twenties = (int)cashBack / 20;
            tens = (int)(cashBack - (twenties * 20)) / 10;
            fives = (int)(cashBack - ((twenties * 20) + (tens * 10))) / 5;
            ones = (int)cashBack - ((twenties * 20) + (tens * 10) + (fives * 5));

            int intToDecimal = (int)cashBack;
            decimal coinChange = cashBack - intToDecimal;

            int toFigureNumberOfCoins = (int)(coinChange * 100);

            quarters = toFigureNumberOfCoins / 25;
            dimes = (toFigureNumberOfCoins - (quarters * 25)) / 10;
            nickels = ((toFigureNumberOfCoins - (quarters * 25) + (dimes * 10)) / 5);

            return "Your change is: " + twenties + " Twenty Dollar Bill(s), " + tens + " Ten(s), " + fives + " Five(s), " + ones + " One(s), " + quarters + " Quarter(s), " + dimes + " Dime(s), " + nickels + " Nickel(s)";


        }

        //  equals = false;

        // }
        //    foreach (CateringItem itemObj in items)
        //    {
        //        if (itemObj.QuantityRemaining == 0)
        //        {
        //           tempString = "SOLD OUT";
        //        }
        //    }
        //    foreach (CateringItem itemObj in items)
        //    {
        //        if (itemObj.QuantityRemaining < intQuantityDesired)
        //        {
        //            tempString = "Not enough quantity of items remaining for desired amount";
        //        }
        //    }
        //    foreach (CateringItem itemObj in items)
        //    {
        //        if ((intQuantityDesired * itemObj.Price) > Balance)
        //        {
        //            tempString = "You a broke ass mutha trucka, go borrow money from Matt Eland, I hear the Java students are filthly rich!!!";
        //        }

        //        tempString = "Product purchased!";

        //    }


        //    return tempString;
        //}





        //if product is sold out, the customer is informed and returned to the Purchase menu
        //if not enough of the product is in stock for the amount the customer requested, inform there is insufficient stock
        //if a valid product is selected it is marked as purchased (???) //log purchase
        //after the product is purchased, the balance should be updated accordingly and the customer returned to Purchase menu



        //switch case 2.3 in UserInterface

        //change given - log each time - see README
        //balance set to 0
        //report displayed that shows items purchased, amount of each item and the total cost for those items and total amount for order


        //new log class: log money added, change given, each purchase
        //new class for AddMoney method so that balance can be passed back and forth?

    }
}

//                Console.WriteLine("");
//                Console.WriteLine("!!!!!!!!!!!!!!!!ERROR!!!!!!!!!!!!!!!!");
//                Console.WriteLine("Nice Try But Please Enter An Integer");
//                Console.WriteLine("!!!!!!!!!!!!!!!!ERROR!!!!!!!!!!!!!!!!");
//                Console.WriteLine("");

//public List<CateringItem> CheckProductCode(string userInput, int intQuantityDesired) // return a string, not a list
//{
//    foreach (CateringItem itemObj in items)
//    {
//        if ((itemObj.Code == userInput) &&// change variable name to productCode
//           (itemObj.QuantityRemaining >= intQuantityDesired) &&
//           (intQuantityDesired * itemObj.Price <= balance)) //balance is 0 here because it's being set in UserInterface
//        {
//            CateringItem tempObject = new CateringItem();
//            tempObject.Type = itemObj.Type;
//            tempObject.Name = itemObj.Name;
//            tempObject.Price = itemObj.Price;

//            purchasedItems.Add(tempObject);

//            decimal cost = intQuantityDesired * itemObj.Price;

//            balance -= cost;
//            return purchasedItems;
//        }

//    }
//    return purchasedItems;
//    //else - send to UserInterface for messages (PRODUCT CODE NOT FOUND/SOLD OUT/NOT ENOUGH PRODUCT/INSUFFICIENT FUNDS)
//}

