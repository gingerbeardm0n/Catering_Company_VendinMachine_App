using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{

    // This class should contain the definition for one catering item

    public class CateringItem
    {
        public int quantity = 50;

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int QuantityRemaining
        {
            get
            {
                return quantity;
            }  //might need to change to private later
        }

        public CateringItem()
        {

        }

        public CateringItem(string code, string name, decimal price, string type)
        {
            Code = code;
            Name = name;
            Price = price;
            Type = type;
                        
        }

        public override string ToString()
        {
            return Code.PadRight(5) + " - " + Name.PadRight(23) + " - " + 
                "$" + Price.ToString().PadRight(7) + " - " + Type.PadRight(5) + 
                " - " +  "Quantity: " + QuantityRemaining;
        }


    }
}
