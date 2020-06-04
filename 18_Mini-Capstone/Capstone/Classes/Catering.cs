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




        //methods

        //switch case 2.2 in UserInterface

        //if product code does not exist, customer is informed and return to Purchase menu
        //if product is sold out, the customer is informed and returned to the Purchase menu
        //if not enough of the product is in stock for the amount the customer requested, inform there is insufficient stock
        //if a valid product is selected it is marked as purchased (???) //log purchase
        //after the product is purchased, the balance should be updated accordingly and the customer returned to Purchase menu



        //switch case 2.3 in UserInterface

        //change given - log each time - see README
        //balance set to 0
        //report displayed that shows items purchased, amount of each item and the total cost for those items and total amount for order
        

        //new log class: log money added, change given, each purchase

    }
}
