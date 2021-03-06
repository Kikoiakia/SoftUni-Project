﻿using System;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to display the cart menu.
    /// </summary>
    public class CartMenu
    {
        /// <summary>
        /// Shows the cart console menu.
        /// </summary>
        /// <param name="cart"></param>
        public void ShowCart(Cart cart)
        {

            string[] commandArgs;
            
            do
            {
                Console.WriteLine("Cart:\n");
                
                if (cart.IsEmpty())
                {
                    Console.WriteLine("Your cart is empty");
                    Console.WriteLine("\nPress B to go Back");
                    commandArgs = Console.ReadLine()?.Split(' ');
                }
                else
                {
                    cart.ShowProductsInCart();
                    Console.WriteLine("\nUse Remove (number) to remove an item from the cart");
                    Console.WriteLine("\nPress B to go Back");
                    Console.Beep(500, 100);

                    commandArgs = Console.ReadLine()?.Split(' ');
                    if (commandArgs?[0].ToUpper() == "REMOVE")
                    {
                        var index = int.Parse(commandArgs[1]);
                        try
                        {
                            cart.RemoveProductFromCart(index);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                        
                    }
                    
                }
                Console.Clear();

            } while (commandArgs?[0].ToUpper() != "B");
            
            
        }
    }
}

/*
 * The cart menu will give acces to the user to view his products and to remove a product from the cart
 */