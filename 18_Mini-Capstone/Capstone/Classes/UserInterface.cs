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
        // be in this class.

        private Catering catering = new Catering();

        public void RunInterface()
        {

            Catering items = new Catering();

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

                        switch (userInput)
                        {
                            case "1":
                                //Add money - method? also track for log
                                break;

                            case "2":
                                //Select Products - also track for log
                                break;

                            case "3":
                                //Complete Transaction
                                break;

                                //also display balance

                        }
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection");
                            break;
                }

                Console.WriteLine();

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
        }

        private void DisplayItems(Catering items)
        {
            CateringItem[] tempItem = items.ItemList; // to review later/ask Matt

            for (int i = 0; i < tempItem.Length; i++)
            {
                Console.WriteLine(tempItem[i].ToString());
            }
        }


        //Add money method

        int balance = 0;

        public int AddMoney(string userInput)
        {
            int deposit = int.Parse(userInput);

            balance += deposit;                

            return balance;
        }

    }
}
