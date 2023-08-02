using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSalman
{
    /*
     * This class represents the factory
     * The factory sells 3 brands: Fendi, Balenciaga and Chanel
     * Each brand has an array of Products they manufacture
     * The factory can add boxes of brands to their stock and sell
     * entire boxes or separate items
     */
    class Factory
    {
        string name;
        //each array represents a shelf that stores the brand's boxes (brand = box)
        Brand[] fendi;
        Brand[] balenciaga;
        Brand[] chanel;
        static double vault;
        string password;

        public Factory()
        {
            //default values, no way to change them as there are no setters
            this.name = "MD inc.";
            fendi = new Brand[2];
            balenciaga = new Brand[2];
            chanel = new Brand[2];
            vault = 0;
            password = "MichalDanielGrade100";
        }
        //getters
        public string GetName() { return this.name; }
        public Brand[] GetFendiShelf() { return this.fendi; }
        public Brand[] GetBalenciagaShelf() { return this.balenciaga; }
        public Brand[] GetChanelShelf() { return this.chanel; }
        //add boxes (if the box is able to sell)
        public void AddFendiBox(Brand fendiBox)
        {
            if (fendiBox.CanSell())
            {
                for (int i = 0; i < fendi.Length; i++)
                {
                    if (fendi[i] == null)
                    {
                        fendi[i] = fendiBox;
                        break;
                    }
                }
            }
        }
        public void AddBalenciagaBox(Brand balenciagaBox)
        {
            if (balenciagaBox.CanSell())
            {
                for (int i = 0; i < balenciaga.Length; i++)
                {
                    if (balenciaga[i] == null)
                    {
                        balenciaga[i] = balenciagaBox;
                        break;
                    }
                }
            }
        }
        public void AddChanelBox(Brand chanelBox)
        {
            if (chanelBox.CanSell())
            {
                for (int i = 0; i < chanel.Length; i++)
                {
                    if (chanel[i] == null)
                    {
                        chanel[i] = chanelBox;
                        break;
                    }
                }
            }
        }
        //sell an item from the corresponding shelf (this sells the first stored item from the first box on shelf)
        public void SellItem(Brand[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != null)
                {
                    Product[] products = b[i].GetProducts();
                    for (int j = 0; j < products.Length; j++)
                    {
                        if (products[j] != null)
                        {
                            double cash = products[j].GetPrice();
                            vault += cash;
                            Console.WriteLine($"Item sold for {cash}$");
                            products[j] = null;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        //sell an entire box from the corresponding shelf (this sells the first box on the shelf)
        public void SellBox(Brand[] b)
        {
            //צריך לבדוק האם החברה שהוכנסה כפרמטר אכן קיימת במפעל
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != null)
                {
                    double cash = b[i].GetBoxPrice();
                    vault += cash;
                    Console.WriteLine($"Box sold for {cash}$");
                    b[i] = null;
                    break;
                }
            }
        }
        //function to return the vault data using password
        public double GetVaultData(string password)
        {
            if (password == this.password)
                return vault;
            else
            {
                Console.WriteLine("Invalid password! Showing -1 instead of true value");
                return -1;
            }
        }
        //count total items for each brand
        public int GetFendiProductsAmount()
        {
            int total = 0;
            for (int i = 0; i < fendi.Length; i++)
            {
                if (fendi[i] != null)
                {
                    Product[] currentBox = fendi[i].GetProducts();
                    for (int j = 0; j < currentBox.Length; j++)
                    {
                        if (currentBox[j] != null)
                            total++;
                    }
                }
            }
            return total;
        }
        public int GetBalenciagaProductsAmount()
        {
            int total = 0;
            for (int i = 0; i < balenciaga.Length; i++)
            {
                if (balenciaga[i] != null)
                {
                    Product[] currentBox = balenciaga[i].GetProducts();
                    for (int j = 0; j < currentBox.Length; j++)
                    {
                        if (currentBox[j] != null)
                            total++;
                    }
                }
            }
            return total;
        }
        public int GetChanelProductsAmount()
        {
            int total = 0;
            for (int i = 0; i < chanel.Length; i++)
            {
                if (chanel[i] != null)
                {
                    Product[] currentBox = chanel[i].GetProducts();
                    for (int j = 0; j < currentBox.Length; j++)
                    {
                        if (currentBox[j] != null)
                            total++;
                    }
                }
            }
            return total;
        }
        //count total items for all brands
        public int GetTotalProductsAmount() { return this.GetFendiProductsAmount() + this.GetBalenciagaProductsAmount() + this.GetChanelProductsAmount(); }
        //get highest item price from what hasn't sold yet
        public double MostExpensiveItemPrice()
        {
            double maxPrice = 0;
            for (int i = 0; i < fendi.Length; i++)
            {
                if (fendi[i] != null)
                {
                    Brand currentBox = fendi[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null)
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice > maxPrice)
                                maxPrice = currentProductPrice;
                        }
                        
                    }
                }
            }
            for (int i = 0; i < balenciaga.Length; i++)
            {
                if (balenciaga[i] != null)
                {
                    Brand currentBox = balenciaga[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null) 
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice > maxPrice)
                                maxPrice = currentProductPrice;
                        }
                        
                    }
                }
            }
            for (int i = 0; i < chanel.Length; i++)
            {
                if (chanel[i] != null)
                {
                    Brand currentBox = chanel[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null)
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice > maxPrice)
                                maxPrice = currentProductPrice;
                        }
                        
                    }
                }
            }
            return maxPrice;
        }
        //get cheapest item price from what hasn't sold yet
        public double CheapestItemPrice()
        {
            double minPrice = this.MostExpensiveItemPrice();
            for (int i = 0; i < fendi.Length; i++)
            {
                if (fendi[i] != null)
                {
                    Brand currentBox = fendi[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null)
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice < minPrice)
                                minPrice = currentProductPrice;
                        }

                    }
                }
            }
            for (int i = 0; i < balenciaga.Length; i++)
            {
                if (balenciaga[i] != null)
                {
                    Brand currentBox = balenciaga[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null)
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice < minPrice)
                                minPrice = currentProductPrice;
                        }

                    }
                }
            }
            for (int i = 0; i < chanel.Length; i++)
            {
                if (chanel[i] != null)
                {
                    Brand currentBox = chanel[i];
                    Product[] currentBoxProducts = currentBox.GetProducts();
                    for (int j = 0; j < currentBoxProducts.Length; j++)
                    {
                        if (currentBoxProducts[j] != null)
                        {
                            double currentProductPrice = currentBoxProducts[j].GetPrice();
                            if (currentProductPrice < minPrice)
                                minPrice = currentProductPrice;
                        }

                    }
                }
            }
            return minPrice;
        }

    }
}
