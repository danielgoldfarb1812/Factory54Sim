using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSalman
{
    /*
     * This class represents the product made by the brand
     * it inherits the brand name of the Brand class
     * and has its own name and price tag
     */
    class Product : Brand
    {
        protected string productName;
        protected double price;
        
        //constructor - if price is illegal set it to 1$
        public Product(string brandName, string productName, double price):base(brandName)
        {
            if (price < 1)
            {
                Console.WriteLine("Price can't be lower than 1. Setting price to 1$");
                this.price = 1;
            }
            else
            {
            this.price = price;
            }
            this.productName = productName;
        }
        //getters & setters
        public string GetProductName() { return this.productName; }
        public void SetProductName(string productName) { this.productName = productName; }
        public double GetPrice() { return this.price; }
        public void SetPrice(double price) { this.price = price; }
    }

}
