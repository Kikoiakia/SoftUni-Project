﻿using System;
using StartUp.Business;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to show the user the available stock menu
    /// </summary>
    public class StockMenu
    {
        /// <summary>
        /// Shows current stock in given store
        /// </summary>
        /// <param name="id"></param>
        public void ShowStock(int id, Cart cart)
        {

            string[] commandArgs;
            do
            {
                Console.WriteLine("Stock:\n");
                var products = new ProductController().GetAllProducts(id);
                int productId = 1;
                foreach (var product in products)
                {
                    Console.WriteLine($"{productId}. {product.Name} : {product.Stock} in stock for {product.Price:f2}$ each until {product.ExpiryDate}");
                    productId++;
                }

                Console.WriteLine($"\nUse Add (Number) (Quantity) to add a product to your cart");
                Console.WriteLine($"\nPress B to go Back");
                Console.Beep(500, 100);

                commandArgs = Console.ReadLine().Split(' ');
                if (commandArgs[0].ToUpper() == "ADD")
                {
                    productId = 1;
                    var quantity = int.Parse(commandArgs[2]);
                    foreach (var product in products)
                    {
                        if (productId == int.Parse(commandArgs[1]))
                        {
                            cart.AddToCart(product, quantity);
                            break;
                        }

                        productId++;
                    }
                }

                Console.Clear();


            } while (commandArgs[0].ToUpper() != "B");
        }
    }
}