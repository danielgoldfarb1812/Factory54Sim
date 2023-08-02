using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSalman
{
    class Program
    {
        /*
         * in the main program we will prompt the user to manage the factory
         * we will check for every possible input and take care of any exceptions that might occur
         */
        static void Main(string[] args)
        {
            
             // set the variables to use later in switch case scenarios
             
            Brand[] fendiShelf;
            Brand[] balenciagaShelf;
            Brand[] chanelShelf;
            int totalSales = 0; // total sales counter to show in the end of the program
            Brand newBox;
            Product[] products;
            Product newProduct;
            int fendiBoxesCount = 0;
            int balenciagaBoxesCount = 0;
            int chanelBoxesCount = 0;
            int choice;
            int brandOfChoice;
            //create the factory using default ctor (password is set using the constructor. if you don't know it - you will miss some functions!)
            Factory myFactory = new Factory();
            Console.WriteLine("Hello human being! What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine($@"Welcome to {myFactory.GetName()}, {name}!
You've been selected as our manager!");
            //the menu will run in a do while loop until user inputs 5 to end the loop
            do
            {

                Console.WriteLine($@"Please choose one of the following options:
1. Add a box of products
2. Sell an item from a box
3. Sell an entire box
4. Show vault balance
5. Exit");
                //check for first user input (if it's not an integer take care of exception)
                while (true)
                {

                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            //add box menu
                            case 1:
                                Console.WriteLine($@"Choose the brand to add a box:
1. Fendi
2. Balenciaga
3. Chanel");
                                //check for add menu user input and take care of exception
                                while (true)
                                {

                                    try
                                    {
                                        brandOfChoice = int.Parse(Console.ReadLine());

                                        //add boxes according to use input. if there's no empty space on the shelf write a message and don't add
                                        switch (brandOfChoice)
                                        {
                                            case 1:
                                                if (fendiBoxesCount == myFactory.GetFendiShelf().Length)
                                                {
                                                    Console.WriteLine("Shelf is full!");
                                                    break;
                                                }
                                                newBox = new Brand("Fendi");
                                                products = newBox.GetProducts();
                                                for (int i = 0; i < products.Length; i++)
                                                {
                                                    Console.WriteLine($"Enter name for product #{i + 1}");
                                                    string productName = Console.ReadLine();
                                                    //each box needs items, each item needs a price. if price isn't a double - catch exception
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine($"Enter price for product #{i + 1}");
                                                            double productPrice = double.Parse(Console.ReadLine());
                                                            newProduct = new Product(newBox.GetBrandName(), productName, productPrice);
                                                            newBox.AddProduct(newProduct);
                                                            break;
                                                        }
                                                        catch (Exception invalidPriceException)
                                                        {
                                                            Console.WriteLine("Price should be DOUBLE");
                                                        }

                                                    }

                                                }
                                                myFactory.AddFendiBox(newBox);
                                                fendiBoxesCount++;
                                                break;

                                            case 2:
                                                if (balenciagaBoxesCount == myFactory.GetBalenciagaShelf().Length)
                                                {
                                                    Console.WriteLine("Shelf is full!");
                                                    break;
                                                }
                                                newBox = new Brand("Balenciaga");
                                                products = newBox.GetProducts();
                                                for (int i = 0; i < products.Length; i++)
                                                {
                                                    Console.WriteLine($"Enter name for product #{i + 1}");
                                                    string productName = Console.ReadLine();
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine($"Enter price for product #{i + 1}");
                                                            double productPrice = double.Parse(Console.ReadLine());
                                                            newProduct = new Product(newBox.GetBrandName(), productName, productPrice);
                                                            newBox.AddProduct(newProduct);
                                                            break;
                                                        }
                                                        catch (Exception invalidPriceException)
                                                        {
                                                            Console.WriteLine("Price should be DOUBLE");
                                                        }

                                                    }

                                                }
                                                myFactory.AddBalenciagaBox(newBox);
                                                balenciagaBoxesCount++;
                                                break;

                                            case 3:
                                                if (chanelBoxesCount == myFactory.GetChanelShelf().Length)
                                                {
                                                    Console.WriteLine("Shelf is full!");
                                                    break;
                                                }
                                                newBox = new Brand("Chanel");
                                                products = newBox.GetProducts();
                                                for (int i = 0; i < products.Length; i++)
                                                {
                                                    Console.WriteLine($"Enter name for product #{i + 1}");
                                                    string productName = Console.ReadLine();
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine($"Enter price for product #{i + 1}");
                                                            double productPrice = double.Parse(Console.ReadLine());
                                                            newProduct = new Product(newBox.GetBrandName(), productName, productPrice);
                                                            newBox.AddProduct(newProduct);
                                                            break;
                                                        }
                                                        catch (Exception invalidPriceException)
                                                        {
                                                            Console.WriteLine("Price should be DOUBLE");
                                                        }

                                                    }

                                                }
                                                myFactory.AddChanelBox(newBox);
                                                chanelBoxesCount++;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid choice! Going back to main menu.");
                                                break;
                                        }
                                        break;

                                    }
                                    catch (Exception addBoxException)
                                    {
                                        Console.WriteLine("**Choice should be an integer** Please choose a valid option for the ADD MENU");
                                    }
                                } //another switch case on box type
                                break;
                            case 2:
                                Console.WriteLine($@"Choose the brand to sell an item from:
1. Fendi
2. Balenciaga
3. Chanel");
                                //check for exception in sell item menu (same as before)
                                while (true)
                                {
                                    try
                                    {
                                        brandOfChoice = int.Parse(Console.ReadLine());
                                        switch (brandOfChoice)
                                        {
                                            case 1:
                                                fendiShelf = myFactory.GetFendiShelf();
                                                myFactory.SellItem(fendiShelf);
                                                totalSales++;
                                                break;

                                            case 2:
                                                balenciagaShelf = myFactory.GetBalenciagaShelf();
                                                myFactory.SellItem(balenciagaShelf);
                                                totalSales++;
                                                break;

                                            case 3:
                                                chanelShelf = myFactory.GetChanelShelf();
                                                myFactory.SellItem(chanelShelf);
                                                totalSales++;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid choice! Going back to main menu.");
                                                break;
                                        }
                                        break;

                                    }
                                    catch (Exception sellItemException)
                                    {
                                        Console.WriteLine("**Choice should be an integer** Please choose a valid option for the SELL ITEM MENU");
                                    }

                                }
                                break;

                            case 3:
                                Console.WriteLine($@"Choose the brand to sell a box from:
1. Fendi
2. Balenciaga
3. Chanel");
                                //check for exceptions in sell box menu
                                while (true)
                                {
                                    try
                                    {
                                        brandOfChoice = int.Parse(Console.ReadLine());
                                        switch (brandOfChoice)
                                        {
                                            case 1:
                                                fendiShelf = myFactory.GetFendiShelf();
                                                myFactory.SellBox(fendiShelf);
                                                totalSales++;
                                                break;

                                            case 2:
                                                balenciagaShelf = myFactory.GetBalenciagaShelf();
                                                myFactory.SellBox(balenciagaShelf);
                                                totalSales++;
                                                break;

                                            case 3:
                                                chanelShelf = myFactory.GetChanelShelf();
                                                myFactory.SellBox(chanelShelf);
                                                totalSales++;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid choice! Going back to main menu.");
                                                break;
                                        }
                                        break;

                                    }
                                    catch (Exception sellBoxException)
                                    {
                                        Console.WriteLine("**Choice should be an integer** Please choose a valid option for the SELL BOX MENU");
                                    }

                                }
                                break;

                            //4 is for showing vault data - ask for password and if it matches show vault value
                            //if password is incorrect it will show -1$
                            case 4:
                                Console.WriteLine("Enter the password for the vault:");
                                Console.ForegroundColor = ConsoleColor.Black;
                                string password = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Current amount in vault:");
                                Console.WriteLine($"{myFactory.GetVaultData(password)}$");
                                break;

                            default:

                                break;
                        }
                        break;
                    }
                    catch (Exception mainMenuException)
                    {
                        Console.WriteLine("**Choice should be an integer** Please choose a valid option for the MAIN MENU");
                    }
                }
            } while (choice != 5);
            //after loop is ended show some details about the factory
            Console.WriteLine($@"Thanks for using our management system, {name}!
Below is the factory data:
Total items in factory: {myFactory.GetTotalProductsAmount()}
Total sales (items and boxes): {totalSales}
Most expensive item in factory: {myFactory.MostExpensiveItemPrice()}$
Cheapest item in factory: {myFactory.CheapestItemPrice()}$
Total Fendi items: {myFactory.GetFendiProductsAmount()}
Total Balenciaga items: {myFactory.GetBalenciagaProductsAmount()}
Total Chanel items: {myFactory.GetChanelProductsAmount()}");
            Console.WriteLine(@"
░██████╗░░█████╗░░█████╗░████████╗██████╗░██╗░░░██╗███████╗  ███╗░░░███╗██████╗░░░░
██╔════╝░██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗╚██╗░██╔╝██╔════╝  ████╗░████║██╔══██╗░░░
██║░░██╗░██║░░██║██║░░██║░░░██║░░░██████╦╝░╚████╔╝░█████╗░░  ██╔████╔██║██████╔╝░░░
██║░░╚██╗██║░░██║██║░░██║░░░██║░░░██╔══██╗░░╚██╔╝░░██╔══╝░░  ██║╚██╔╝██║██╔══██╗░░░
╚██████╔╝╚█████╔╝╚█████╔╝░░░██║░░░██████╦╝░░░██║░░░███████╗  ██║░╚═╝░██║██║░░██║██╗
░╚═════╝░░╚════╝░░╚════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝

███╗░░░███╗░█████╗░███╗░░██╗░█████╗░░██████╗░███████╗██████╗░██╗
████╗░████║██╔══██╗████╗░██║██╔══██╗██╔════╝░██╔════╝██╔══██╗██║
██╔████╔██║███████║██╔██╗██║███████║██║░░██╗░█████╗░░██████╔╝██║
██║╚██╔╝██║██╔══██║██║╚████║██╔══██║██║░░╚██╗██╔══╝░░██╔══██╗╚═╝
██║░╚═╝░██║██║░░██║██║░╚███║██║░░██║╚██████╔╝███████╗██║░░██║██╗
╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚═╝╚═╝");
        }
        
    }
}
