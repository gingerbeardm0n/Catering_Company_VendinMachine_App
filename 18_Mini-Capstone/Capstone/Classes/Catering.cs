using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{


    public class Catering : IAuditLog

    {
        public void AuditLog()
        {

        }
        public void AuditLog(int deposit, decimal Balance) // for Add Money
        {
            using (StreamWriter sw = new StreamWriter(@"c:\Catering\Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + "  " + "ADD MONEY:  " + "$" + deposit + "  " + "$" + Balance);
            }
        }

        public void AuditLog(decimal Balance) // for give change
        {
            using (StreamWriter sw = new StreamWriter(@"c:\Catering\Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + "  " + "GIVE CHANGE:  " + "$" + Balance + "  " + "$0.00");
            }
        }

        public void AuditLog(int intQuantityRequested, decimal balance, CateringItem itemObj) // for purchases
        {
            using (StreamWriter sw = new StreamWriter(@"c:\Catering\Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + "  " + intQuantityRequested + "  " + 
                    itemObj.Name + "  " + itemObj.Code + "  " +  "$" + 
                    (intQuantityRequested * itemObj.Price) + "  " + "$" + Balance);
                
            }
        }
        
        // make constructor that reads catering file and adds to list
        // This class should contain all the "work" for catering

        public decimal Balance { get; private set; }

        public decimal TotalCost { get; set; }

        public List<CateringItem> PurchasedItems { get; private set; } = new List<CateringItem>();
        
        public Catering(decimal balance, decimal totalCost)
        {
            Balance = balance;
            TotalCost = totalCost;
        }
        //-----------------------------------------------------------------------------------------------------------------
        // This constructor, property, and method are working in conjunction to read in CSV file and convert to a list of catering items, AKA it makes
        // the data accessible to us as programmers to use as we sit fit

        private List<CateringItem> items = new List<CateringItem>();

        //Method ReadItems() is pre-determined method that returns a List of type catering items.
        private List<CateringItem> ReadItems()
        {
            FileAccess fa = new FileAccess();
            return fa.ReadItems();
        }
        //  Use the method ReadItems() to pull data from desired file and store it inside the list "items" (instantiated few line above)
        public Catering()
        {
            items = ReadItems();
        }
        //Use this property to (ASK for HELP here, not sure we fully understand)
        public CateringItem[] ItemList //never seen a property be of type Class, let alone of type class[].
        {
            get
            {
                return items.ToArray(); // Taking a list of objects (CateringItem) and putting into an array - why?
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------

        public string AddMoney(string userInput) //log everytime money is added
        {
            int deposit = 0;
            try
            {
                deposit = int.Parse(userInput);

                if (deposit >= 0 && deposit + Balance <= 5000)

                {
                    Balance += deposit;

                    AuditLog(deposit, Balance); // to print out to Log.txt
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

                   itemObj.IntQuantityDesired = intQuantityDesired;

                    AuditLog(intQuantityDesired, Balance, itemObj);

                    PurchasedItems.Add(itemObj);

                    TotalCost += (itemObj.IntQuantityDesired * itemObj.Price);

                    return "ITEM ADDED TO CART";
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
            return "PRODUCT CODE NOT FOUND";
        }

        public void Purchase(CateringItem purchasedItem, int intQuantityDesired)
        {
           Balance -= (purchasedItem.Price * intQuantityDesired);
        
        }
        
        public string PrintPurchases(List<CateringItem> PurchasedItems)
        {
            string result = "";

            foreach (CateringItem item in PurchasedItems)
            {
                result += item.IntQuantityDesired.ToString().PadRight(2) + "                " + item.Type.PadRight(4) + 
                    "   " + item.Name.PadRight(20) + "   " + "$" + item.Price.ToString().PadRight(2) + "   " + 
                    "$" + (item.IntQuantityDesired * item.Price).ToString().PadRight(2) + "\n";
            }

            return result;
        }

        public string BalanceToZero()
        {
            Balance = 0;
            List<CateringItem> emptyList = new List<CateringItem>();
            PurchasedItems = emptyList;
            
            return "Your change has been returned and your balance is $0. Thank you!";
        }
        
        public string GiveChange(decimal balance)
        {
            AuditLog(Balance); //to print out to Log.txt

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
            nickels = (toFigureNumberOfCoins - ((quarters * 25) + (dimes * 10))) / 5;

            return "Your change is " + "$" + cashBack + " in the form of: " + twenties + 
                " Twenty Dollar Bill(s), " + tens + " Ten(s), " + fives + " Five(s), " + 
                ones + " One(s), " + quarters + " Quarter(s), " + dimes + " Dime(s), " + 
                nickels + " Nickel(s)";
        }
    }
}


