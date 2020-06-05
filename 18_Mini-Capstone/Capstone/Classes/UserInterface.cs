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

        

        private Catering catering = new Catering();

        Catering items = new Catering();
        CateringItem cateringItem = new CateringItem();
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
                    case "1":
                        DisplayItems(items);
                        break;

                    case "2":
                       

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
                                case "2":

                                    Console.WriteLine("Please enter valid product code");
                                    string checkProduct = Console.ReadLine();

                                    Console.WriteLine("Please enter desired quantity");
                                    string strQuantityDesired = Console.ReadLine();

                                    cateringItem.IntQuantityDesired = int.Parse(strQuantityDesired);

                                    string checkProductMessage = items.CheckProductCode(checkProduct, cateringItem.IntQuantityDesired);
                                    Console.WriteLine(checkProductMessage);

                                    if (checkProductMessage == "Purchased!")
                                    {
                                        items.Purchase(cateringItem.IntQuantityDesired, items.Balance);
                                    }



                                    break;
                                case "3":
                                    //items.UpdateTotalCost(cateringItem.IntQuantityDesired);
                                    string cashBack = items.GiveChange(items.Balance);
                                    Console.WriteLine(cashBack);
                                    string printList = items.PrintPurchases(items.PurchasedItems);
                                    Console.WriteLine(printList); // this needs resolved

                                    string checkOut = items.BalanceToZero();
                                    Console.WriteLine(checkOut);

                                    Console.WriteLine("Press enter to return");
                                    Console.ReadLine();
                                    isDone = true;

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
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }

                Console.WriteLine(); //blank line

               
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
            Console.WriteLine(); //Blank line
        }

        private void DisplayItems(Catering items)
        {
            CateringItem[] tempItem = items.ItemList; // to review later/ask Matt

            for (int i = 0; i < tempItem.Length; i++)
            {
                Console.WriteLine(tempItem[i].ToString());
            }
        }

    }
}
