using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class UserInterface
    {
        
        private Catering catering = new Catering();

        Catering items = new Catering();
        
        public void RunInterface()
        {
            string userInput = "";
            
            bool isFinished = false;
            while (!isFinished)
            { 
            MainMenu();

            userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1": // Case 1.1 - Display Items
                        DisplayItemCategories();
                        DisplayItems(items);
                        break;

                    case "2": // Case 1.2 - Go to order menu
                       
                        bool isDone = false;
                        while (!isDone)
                        {
                            PurchaseMenu();

                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":    // Case 2.1 - Add Money to Balance 
                                    Console.WriteLine("Please enter deposit amount (must be an integer)");
                                    userInput = Console.ReadLine();
                                    string addMoneyMessage = items.AddMoney(userInput);
                                    Console.WriteLine(addMoneyMessage);
                                    
                                    break;
                                case "2":  // Case 2.2 - Select Items

                                    Console.WriteLine("Please enter valid product code");
                                    string checkProduct = Console.ReadLine();

                                    Console.WriteLine("Please enter desired quantity");
                                    string strQuantityDesired = Console.ReadLine();

                                    int intQuantityDesired = int.Parse(strQuantityDesired);

                                    string checkProductMessage = items.CheckProductCode(checkProduct, intQuantityDesired);
                                    Console.WriteLine(checkProductMessage);
                                    
                                    //  This is taking the checkProduct input from the user and grabbing the item from the database 
                                    //  (items.ItemList), which was used in Catering to create the initial list from the data file

                                    CateringItem selectedItem = null;

                                    foreach (CateringItem item in items.ItemList)
                                    {
                                        if (item.Code == checkProduct)
                                        {
                                            selectedItem = item; //allows us to get selected item and pass in below
                                            break;
                                        }
                                    }
                                    if (checkProductMessage == "ITEM ADDED TO CART")
                                    {
                                        items.Purchase(selectedItem, intQuantityDesired);
                                    }
                                    break;
                                case "3": // Case 2.3 - Complete Transaction
                                    
                                    string cashBack = items.GiveChange(items.Balance);
                                    Console.WriteLine(cashBack);

                                    DisplayPurchasesCategories();

                                    string printList = items.PrintPurchases(items.PurchasedItems);
                                    Console.WriteLine(printList);

                                    string checkOut = items.BalanceToZero();
                                    Console.WriteLine(checkOut);
                                    Console.WriteLine("Press enter to return to main menu");
                                    Console.ReadLine();

                                    isDone = true; //ends the while loop

                                    break;
                                default:
                                    Console.WriteLine("Please make a valid selection");
                                    break;
                            }
                            Console.WriteLine(); //blank line
                        }
                        break;

                    case "3":
                        isFinished = true;
                        Console.WriteLine("Press Enter To Exit, Enjoy Your Tasty Tasty Food");
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
                Console.WriteLine(); //blank line
            }
        }


        //-------Methods--------------------------------------------------------------------------------------------------
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
            Console.WriteLine(); //Blank line
        }

        private void DisplayItemCategories()
        {
            Console.WriteLine(" CODE   NAME                   PRICE      TYPE    QUANTITY REMAINING");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        private void DisplayItems(Catering items)
        {
            
            CateringItem[] tempItem = items.ItemList; // to review later/ask Matt

            for (int i = 0; i < tempItem.Length; i++)
            {
                Console.WriteLine(tempItem[i].ToString());
            }
        }

        private void DisplayPurchasesCategories()
        {
            Console.WriteLine("QUANTITY BOUGHT   TYPE   NAME                   PRICE   TOTAL COST");
            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}

