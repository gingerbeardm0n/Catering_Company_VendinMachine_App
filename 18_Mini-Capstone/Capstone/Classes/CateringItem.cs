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
        public int IntQuantityDesired { get; set; }
        public int QuantityRemaining
        {
            get
            {
                return quantity - IntQuantityDesired;
            }
            set
            {
                QuantityRemaining = value;
            }
            
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

        public override string ToString() //using this to override the ToString Method in UserInterface line 141
        {
            return " " + Code.PadRight(7) + Name.PadRight(23) +
                "$" + Price.ToString().PadRight(10) + Type.PadRight(8) +
                 +QuantityRemaining;
        }


    }
}
