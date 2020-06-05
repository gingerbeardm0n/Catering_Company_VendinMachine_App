using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // make constructor that reads catering file and adds to list
        // This class should contain all the "work" for catering

        public decimal Balance { get; private set; }

        public Catering (decimal balance)
        {
            Balance = balance;
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
        
        private decimal balance = 0;
        
        public string AddMoney(string userInput) //log everytime money is added
        {
            int deposit = 0;
            try
            {
                deposit = int.Parse(userInput);

                if (deposit >= 0 && deposit + balance <= 5000)

                {
                    balance += deposit;
                }
                else
                {
                    return "Balance must be between 0 and 5000";
                }
            }
            catch (Exception e)
            {
                return "You must enter an integer";
            }
            return "Your account balance is: " + "$" + balance;
            
        }

        //switch case 2.2 in UserInterface
        
        //if product code does not exist, customer is informed and return to Purchase menu

        // JOEL COMMENTING OUT CheckProductCode METHOD b/c I moved it over to UserInterface

        List<CateringItem> purchasedItems = new List<CateringItem>();

        public string CheckProductCode(string productCode, int intQuantityDesired)
        {
            string tempString1 = "";
            string tempString2 = "";
            string tempString3 = "";
            string tempString4 = "";

            foreach (CateringItem itemObj in items)
            {
                if (productCode == itemObj.Code)
                {
                    tempString1 = "";
                }
                else
                {
                    return "Product code does NOT exist";
                }
                if (itemObj.QuantityRemaining == 0)
                {
                    return "SOLD OUT";
                }
                if (itemObj.QuantityRemaining < intQuantityDesired)
                {
                    return "Not enough quantity of items remaining for desired amount";
                }
                if ( (intQuantityDesired * itemObj.Price) > balance)
                {
                    return "You a broke ass mutha trucka, go borrow money from Matt Eland, I hear the Java students are filthly rich!!!";
                }
            }
            return tempString1;
        }





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

