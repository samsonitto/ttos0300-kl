using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    public class Product
    {
        //PROPERTIES
        public string Name { get; set; }
        public float Price { get; set; }
        //CONSTRUCTORS
        public Product()
        {

        }
        public Product (string name, float price)
        {
            Name = name;
            Price = price;
        }
        //METHODS
        public override string ToString()
        {
            return $"{Name} {Price}€";
        }
        //EVENTS
    }
}
