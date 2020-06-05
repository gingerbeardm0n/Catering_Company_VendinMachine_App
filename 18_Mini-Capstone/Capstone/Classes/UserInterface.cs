using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class

        //decimal balance = 0;
        //int deposit = 0;

        private Catering catering = new Catering();

        Catering items = new Catering();
        public void RunInterface()
        {


            string userInput = "";

            MainMenu();

            userInput = Console.ReadLine();

            while (userInput != "3")
            {
                switch (userInput)
                {
                    case "1":
                        DisplayItems(items);
                        break;

                    case "2":
                        PurchaseMenu();
                        userInput = Console.ReadLine();

                        while (userInput != "3")
                        {

                            switch (userInput)
                            {
                                case "1":    // Case 2.1 - Add Money to Balance 
                                    Console.WriteLine("Please enter deposit amount (must be an integer)");
                                    userInput = Console.ReadLine();
                                    string addMoneyMessage = items.AddMoney(userInput);
                                    Console.WriteLine(addMoneyMessage);

                                    break;
                                case "2":

                                    Console.WriteLine("Please enter valid product code");
                                    string productCode = Console.ReadLine();

                                    Console.WriteLine("Please enter desired quantity");
                                    string strQuantityDesired = Console.ReadLine();

                                    int intQuantityDesired = int.Parse(strQuantityDesired);

                                    string checkProductMessage = items.CheckProductCode(userInput, intQuantityDesired);
                                    Console.WriteLine(checkProductMessage); //string message variable here

                                    break;
                                case "3":
                                    //Complete Transaction
                                    break;
                            }
                            Console.WriteLine(); //blank line

                            PurchaseMenu();

                            userInput = Console.ReadLine();
                        }
                        break;

                    case "3":
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }

                Console.WriteLine(); //blank line

                MainMenu();

                userInput = Console.ReadLine();
            }

        }

        //Methods

        private void MainMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
        }

        private void PurchaseMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: $" + items.Balance);
        }

        private void DisplayItems(Catering items)
        {
            CateringItem[] tempItem = items.ItemList; // to review later/ask Matt

            for (int i = 0; i < tempItem.Length; i++)
            {
                Console.WriteLine(tempItem[i].ToString());
            }
        }


        //decimal balance = 0;  --> this variable is define at top of UserInterface class
        //int deposit = 0;  --> this variable is define at top of UserInterface class

        //private void AddMoney(string userInput) //log everytime money is added // Joel changed return type to void
        //{
        //    try
        //    {
        //        deposit = int.Parse(userInput);

        //        if (deposit >= 0 && deposit + balance <= 5000)

        //        {
        //            balance += deposit;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Balance must be between 0 and 5000");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("");
        //        Console.WriteLine("!!!!!!!!!!!!!!!!ERROR!!!!!!!!!!!!!!!!");
        //        Console.WriteLine("Nice Try But Please Enter An Integer");
        //        Console.WriteLine("!!!!!!!!!!!!!!!!ERROR!!!!!!!!!!!!!!!!");
        //        Console.WriteLine("");
        //    }
        //    Console.WriteLine("Your account balance is: " + "$" + balance);

        //    //return balance; - Joel commenting out to see if we can out purchase menu as the return to
        //    //                  have it just loop back to the purchase menu anytime we add money

        //}

        //List<CateringItem> purchasedItems = new List<CateringItem>();

        //public List<CateringItem> CheckProductCode(string userInput, int intQuantityDesired)
        //{
        //    foreach (CateringItem itemObj in items)

        //        if ((itemObj.Code == userInput) &&
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
        //        }

        //    //else - send to UserInterface for messages (PRODUCT CODE NOT FOUND/SOLD OUT/NOT ENOUGH PRODUCT/INSUFFICIENT FUNDS)

        //    return purchasedItems;


        //}

    }
}
