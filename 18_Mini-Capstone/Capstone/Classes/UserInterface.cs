﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class UserInterface
    {
        //---------- INSTANTIATION ------------------------------------------------------------------------------------------------------------------------------------------
        private Catering catering = new Catering();

        Catering items = new Catering();

        //---------- RunInterface METHOD ---------------------------------------------------------------------------------------------------------------------------------------------

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
                            Console.WriteLine();
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

                                    Console.WriteLine(); //blank line
                                    Console.WriteLine("Please enter valid product code");
                                    string checkProduct = Console.ReadLine();

                                    Console.WriteLine(); //blank line
                                    Console.WriteLine("Please enter desired quantity");
                                    string strQuantityDesired = Console.ReadLine();

                                    int intQuantityDesired = int.Parse(strQuantityDesired);

                                    string checkProductMessage = items.PurchaseIndividualItem(checkProduct, intQuantityDesired);
                                    Console.WriteLine(checkProductMessage);
                                    
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
                                        items.UpdateBalance(selectedItem, intQuantityDesired);
                                    }
                                    break;
                                case "3": // Case 2.3 - Complete Transaction

                                    TenderChange();
                                    
                                    Console.WriteLine("List of purchased items and total cost this transaction:");
                                    Console.WriteLine();

                                    DisplayPurchasesCategories();

                                    string printList = items.PrintPurchases(items.PurchasedItems);
                                    Console.WriteLine(printList);
                                    Console.WriteLine(); //blank line
                                    Console.WriteLine("Total: " + items.TotalCost);

                                    Console.WriteLine(); //blank line
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
        //---------- END RunInterface METHOD ---------------------------------------------------------------------------------------------------------------------------------------------


        //------- DISPLAY METHODS ------------------------------------------------------------------------------------------------------------------------------------

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
            List<CateringItem> displayList = new List<CateringItem>();
            CateringItem[] tempItem = items.ItemList; // to review later/ask Matt

            for (int i = 0; i < tempItem.Length; i++)
            {
                 string temp = tempItem[i].ToString();

                string tempSub2 = temp.Substring(0, temp.Length - 2);
                string tempSub = temp.Substring(temp.Length - 2, 2);
                if (tempSub == " 0")
                {
                    tempSub = "SOLD OUT";
                }
                Console.WriteLine(tempSub2 + tempSub);
            }
        }

        private void DisplayPurchasesCategories()
        {
            Console.WriteLine("QUANTITY BOUGHT   TYPE   NAME                   PRICE   TOTAL COST");
            Console.WriteLine("------------------------------------------------------------------");
        }

        private void TenderChange()
        {
            List<int> cashBack = items.CalculateChange(items.Balance);

            Console.WriteLine();
            Console.WriteLine("Thank you for your purchase(s)! Your total change is " + items.Balance +
                " and is now refunded to you in the form of:");
            Console.WriteLine();

            if (cashBack[0] == 1)
            {
                Console.WriteLine(cashBack[0].ToString().PadRight(3) + "  TWENTY");
            }
            else if (cashBack[0] > 1)
            {
                Console.WriteLine(cashBack[0].ToString().PadRight(3) + "  TWENTIES");
            }
            if (cashBack[1] == 1)
            {
                Console.WriteLine(cashBack[1].ToString().PadRight(3) + "  TEN");
            }
            else if (cashBack[1] > 1)
            {
                Console.WriteLine(cashBack[1].ToString().PadRight(3) + "  TENS");
            }
            if (cashBack[2] == 1)
            {
                Console.WriteLine(cashBack[2].ToString().PadRight(3) + "  FIVE");
            }
            else if (cashBack[2] > 1)
            {
                Console.WriteLine(cashBack[2].ToString().PadRight(3) + "  FIVES");
            }
            if (cashBack[3] == 1)
            {
                Console.WriteLine(cashBack[3].ToString().PadRight(3) + "  ONE");
            }
            else if (cashBack[3] > 1)
            {
                Console.WriteLine(cashBack[3].ToString().PadRight(3) + "  ONES");
            }
            if (cashBack[4] == 1)
            {
                Console.WriteLine(cashBack[4].ToString().PadRight(3) + "  quarter");
            }
            else if (cashBack[4] > 1)
            {
                Console.WriteLine(cashBack[4].ToString().PadRight(3) + "  quarters");
            }
            if (cashBack[5] == 1)
            {
                Console.WriteLine(cashBack[5].ToString().PadRight(3) + "  dime");
            }
            else if (cashBack[5] > 1)
            {
                Console.WriteLine(cashBack[5].ToString().PadRight(3) + "  dimes");
            }
            if (cashBack[6] == 1)
            {
                Console.WriteLine(cashBack[6].ToString().PadRight(3) + "  nickel");
            }
            else if (cashBack[6] > 1)
            {
                Console.WriteLine(cashBack[6].ToString().PadRight(3) + "  nickels");
            }
            Console.WriteLine();
        }
    }
}

