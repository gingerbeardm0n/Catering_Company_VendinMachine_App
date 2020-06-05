using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // make constructor that reads catering file and adds to list
        // This class should contain all the "work" for catering

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

        decimal balance = 0;
        int deposit = 0;

        public decimal AddMoney(string userInput) //log everytime money is added
        {

            try
            {
                deposit = int.Parse(userInput);

                if (deposit >= 0 && deposit + balance <= 5000)

                {
                    balance += deposit;
                }
                else
                {
                    Console.WriteLine("Balance must be between 0 and 5000");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Nice try but please enter an integer");
            }


            Console.WriteLine("Your account balance is: " + "$" + balance);

            return balance;
        }

        //switch case 2.2 in UserInterface



        //if product code does not exist, customer is informed and return to Purchase menu

        List<CateringItem> purchasedItems = new List<CateringItem>();

        public List<CateringItem> CheckProductCode(string userInput, int intQuantityDesired)
        {
            foreach (CateringItem itemObj in items)

                if ((itemObj.Code == userInput) &&
                   (itemObj.QuantityRemaining >= intQuantityDesired) &&
                   (intQuantityDesired * itemObj.Price <= balance)) //balance is 0 here because it's being set in UserInterface
                {
                    CateringItem tempObject = new CateringItem();
                    tempObject.Type = itemObj.Type;
                    tempObject.Name = itemObj.Name;
                    tempObject.Price = itemObj.Price;

                    purchasedItems.Add(tempObject);

                    decimal cost = intQuantityDesired * itemObj.Price;

                    balance -= cost;
                }

            //else - send to UserInterface for messages (PRODUCT CODE NOT FOUND/SOLD OUT/NOT ENOUGH PRODUCT/INSUFFICIENT FUNDS)

            return purchasedItems;


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
