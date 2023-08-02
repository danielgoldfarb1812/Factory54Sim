using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSalman
{
    /*
     * This class represents the brand that manufactures products
     * The products are stored as an array of products
     * Each brand has its own name and the products they manufacture
     * Each brand can make up to 100 products
     * Once the brand reaches 100 products they can export them to the factory and sell
     */
    class Brand
    {
        protected string brandName;
        protected Product[] products;
        public Brand(string brandName)
        {
            this.brandName = brandName;
            this.products = new Product[100];
        }
        //getters & setters (won't be used in the main program but can be used to change the brand name to something the factory doesn't sell)
        public void SetBrandName(string brandName) { this.brandName = brandName; }
        public string GetBrandName() { return this.brandName; }
        //function to add a product to the array
        public void AddProduct(Product p)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = p;
                    break;
                }
            }
        }
        //check if the array is full of products. if it is - it can be sold to the factory
        public bool CanSell()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null) return false;
            }
            return true;
        }
        //get entire box price
        public double GetBoxPrice()
        {
            double price = 0;
            for (int i = 0; i < products.Length; i++)
            {
                price += products[i].GetPrice();
            }
            return price;
        }
        //get the product array to use the Product.cs functions
        public Product[] GetProducts() { return this.products; }
    }
}
