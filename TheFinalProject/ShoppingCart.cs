﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheFinalProject
{
    internal class ShoppingCart
    {
        //Static list that holds our shoppingCart items since we only want
        //one instance of it.
         static public List<Item> ShoppingCartList = new List<Item>();
         static public void AddItemToShoppingCart(Item item)
        {
            //Only compares item ID if the cart is not empty. Otherwise there is nothing
            //to compare with
            if (ShoppingCartList.Count != 0)
            {
                foreach (var cartitem in ShoppingCartList)
                {
                    if (cartitem.ID == item.ID)
                    {
                        //Changes the quantity of a item that is already in 
                        //the cart instead of creating a new copy of the same
                        //item.
                        cartitem.Quantity += item.Quantity;
                    }
                    else
                    {
                        ShoppingCartList.Add(item);
                        break;
                    }
                }
            }
            //If the cart is empty, add the item.
            else
            {
                ShoppingCartList.Add(item);
            }
           
                     
        }
         static public double AddTotalValue()
        {
            //Multiples all items quantity with their price 
            //and add them together
            double totalPrice = 0;
            foreach (Item item in ShoppingCartList)
            {
                double quantity = item.Quantity;
                double price = item.Price;
                totalPrice += quantity * price;
            }
            return totalPrice;
        }
         static public void ViewCart()
        {
            double totalprice = AddTotalValue();
            //Displays all items that are in the cart
            Console.WriteLine("CART");
            foreach (Item item in ShoppingCartList)
            {
                Console.WriteLine($"{item.Name}     x{item.Quantity}\n");
            }
            Console.WriteLine($"------------------\nTOTAL: {totalprice}$\n");
            bool menu = true;
            while (menu) 
            {
                Console.Write("[1]CONFIRM PURCHASE   [2]REMOVE ITEM   [3]RETURN TO MAIN MENU\n");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice) 
                {
                    case 1:
                        ConfirmPurchase();
                        menu = false; 
                        break;
                    case 2:
                        RemoveItem();
                        menu = false;
                        break;
                    case 3:
                        Console.Clear();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE PICK AN EXISTING OPTION");
                        break;
                }
            }

        }
         static public void ConfirmPurchase()
        {
            Console.WriteLine("WOULD YOU LIKE TO CONFIRM YOUR PURCHASE [1]YES [2]NO");
            bool menu = true;
            while (menu)
            {
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        //Makes sure that you cannot buy an empty cart
                        if (ShoppingCartList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("THERE ARE NO ITEMS IN YOU CART TO PURCHASE");
                            menu = false;
                            ViewCart();
                        }
                        //Otherwise clear the cart of all items.
                        else
                        {
                            ShoppingCartList.Clear();
                            Console.Clear();
                            Console.WriteLine("THANK YOU FOR YOUR PURCHASE");
                        }
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    case 2:
                        Console.Clear();
                        ViewCart();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE PICK AN EXISTING OPTION");
                        break;
                }

            }
        }
         static public void RemoveItem() 
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("[1]REMOVE ITEM   [2]CLEAR CART");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        RemoveSpecificItem();
                        ViewCart();
                        menu = false;
                        break;
                    case 2:
                        //Checks that there are items to remove
                        if (ShoppingCartList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("THERE ARE NO ITEMS TO REMOVE");
                        }
                        else
                        {
                            Console.Clear();
                            //Removes all item from cart
                            foreach (var cartItem in ShoppingCartList)
                            {
                                foreach (var catalogItem in ItemOrganisation.itemList)
                                //Compares the ID of items in cart with those of the catalog
                                //and readds all the stock removed from ShoppingCart
                                if (catalogItem.ID == cartItem.ID)
                                {
                                    catalogItem.Quantity += cartItem.Quantity;
                                }
                            }
                            //After all the stock has been readded we remove empty the cart
                            ShoppingCartList.Clear();
                            Console.WriteLine("YOU JUST CLEARED THE CART");
                        }
                        ViewCart();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("THIS IS NOT A VALID OPTION");
                        break;
                }
            }
        }
         static public void RemoveSpecificItem()
        {
            bool choiceLoop = true;
            int i = 1;
            //Displays all item in cart
            foreach (Item item in ShoppingCartList)
            {
                Console.WriteLine($"====================\n\t[{i}]\n{item}\n====================");
                i++;
            }
            while (choiceLoop)
            {
                Console.Write("ENTER THE # OF THE ITEM YOU WISH TO REMOVE (0 TO RETURN): ");
                Int32.TryParse(Console.ReadLine(), out int indexChoice);
                if (indexChoice == 0)
                {
                    Console.Clear();
                    choiceLoop = false;
                    ViewCart();
                }
                //If the choosen item exsists in the cart choose how many
                //to remove.
                else if (indexChoice >= 1 && indexChoice <= ShoppingCartList.Count)
                {
                    Item selectedItem = ShoppingCartList[indexChoice - 1];
                    Console.Clear();
                    Console.WriteLine($"HOW MANY OF {selectedItem.Name} DO YOU WANT TO REMOVE (YOU HAVE {selectedItem.Quantity} IN CART)");
                    Int32.TryParse(Console.ReadLine(), out int quantityToRemove);
                    if (quantityToRemove > 0 && quantityToRemove <= selectedItem.Quantity)
                    {
                        if (quantityToRemove == selectedItem.Quantity)
                        {
                            //Returns the stock of the specifide item to itemList
                            foreach (var catalogItem in ItemOrganisation.itemList)
                            {
                                if (catalogItem.ID == selectedItem.ID)
                                {
                                    catalogItem.Quantity += quantityToRemove;
                                }
                            }   
                            //Removes the specifide item from the cart since it has 0 quantity
                            ShoppingCartList.RemoveAt(indexChoice - 1);
                        }
                        else
                        {
                            //Returns the stock of the specifide item to itemList
                            foreach (var catalogItem in ItemOrganisation.itemList)
                            {
                                if (catalogItem.ID == selectedItem.ID)
                                {
                                    catalogItem.Quantity += quantityToRemove;
                                }
                            }
                            //Reduces quantity in cart based on how many the user wanted to remove
                            ShoppingCartList[indexChoice - 1].Quantity -= quantityToRemove;
                        }
                        Console.Clear();
                        Console.WriteLine($"YOU REMOVED {quantityToRemove}x {selectedItem.Name} FROM THE CART!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("NOT A VALID OPTION");
                        ViewCart();
                    }
                    choiceLoop = false;
                    ViewCart();
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("NOT A VALID OPTION");
                    ViewCart();
                }

            }
        }
    }
        
}
