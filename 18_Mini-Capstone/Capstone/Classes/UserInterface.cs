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

        decimal balance = 0;

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
                        userInput = Console.ReadLine();

                        while (userInput != "3")
                        {

                            switch (userInput)
                            {
                                case "1":
                                    Console.WriteLine("Please enter deposit amount (must be an integer)");
                                    userInput = Console.ReadLine();
                                    Catering temp = new Catering();
                                    balance = temp.AddMoney(userInput);
                                    break;

                                case "2":

                                    Console.WriteLine("Please enter valid product code");
                                    userInput = Console.ReadLine();
                                    Console.WriteLine("Please enter desired quantity");
                                    string strQuantityDesired = Console.ReadLine();
                                    int intQuantityDesired = int.Parse(strQuantityDesired);
                                    Catering temp2 = new Catering();
                                    temp2.CheckProductCode(userInput, intQuantityDesired);
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
            Console.WriteLine("Current Account Balance: $" + balance);
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
