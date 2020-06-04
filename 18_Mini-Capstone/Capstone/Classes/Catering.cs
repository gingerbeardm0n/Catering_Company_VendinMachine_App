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
   
    }
}
