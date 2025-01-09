using System;
using System.Collections.Generic;
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
        static public List<Item> ShoppingCartList = new List<Item>();
        static public void AddItemToShoppingCart(Item item, int qunaitity)
        {
            item.Quantity = qunaitity;
            ShoppingCartList.Add(item);
        }
        static public int Addtotalvalue()
        {
            int totalPrice = 0;
            foreach (Item item in ShoppingCartList)
            {
                int quantity = item.Quantity;
                int price = item.Price;
                totalPrice += quantity * price;
            }
            return totalPrice;
        }
        static public void ViewCart()
        {
            int totalprice = Addtotalvalue();
            Console.WriteLine("Cart");
            foreach (Item item in ShoppingCartList)
            {
                Console.WriteLine($"{item.Name}     x{item.Quantity}\n");
            }
            Console.WriteLine($"------------------\nTOTAL: {totalprice}$\n");
            bool menu = true;
            while (menu) 
            {
                Console.Write("[1]Confirm Purchase   [2]Remove Item   [3]Return to Main menu");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice) 
                {
                    case 1:
                        ConfirmPurchase();
                        menu = false; 
                        break;
                    case 2:
                        RemoveItem();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    case 3:
                        Console.Clear();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("This is not a valid syntax");
                        break;
                }
            }

        }
        static public void ConfirmPurchase()
        {
            Console.WriteLine("Would you like to confirm your purchase [1]Yes [2]No");
            bool menu = true;
            while (menu)
            {
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        ShoppingCartList.Clear();
                        Console.Clear();
                        Console.WriteLine("Thank you for your purchase");
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    case 2:
                        Console.Clear();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("not a valid syntax");
                        break;
                }

            }
        }
        static public void RemoveItem() 
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("[1]Remove item   [2]Clear Cart");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        RemoveSpecificItem();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    case 2:
                        ShoppingCartList.Clear();
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("This is not a valid syntax");
                        break;
                }
            }
        }
        static void RemoveSpecificItem()
        {
            bool choiceLoop = true;
            int i = 1;
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
                    Menu.GoToMenu();
                }
                else if (indexChoice >= 1 && indexChoice <= ShoppingCartList.Count)
                {
                    Item selectedItem = ShoppingCartList[indexChoice - 1];
                    Console.WriteLine("HOW MANY OF SELECTED ITEM DO YOU WISH TO REMOVE");
                    Int32.TryParse(Console.ReadLine(), out int quantityToRemove);
                    if (quantityToRemove > 0 && quantityToRemove <= ShoppingCartList.Count(item => item.Equals(selectedItem)))
                    {
                        int count = 0;
                        for (int j = ShoppingCartList.Count - 1; j >= 0 && count < quantityToRemove; j--)
                        {
                            if (ShoppingCartList[j].Equals(selectedItem))
                            {
                                ShoppingCartList.RemoveAt(j);
                                count++;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine($"{quantityToRemove} items removed from the cart.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid syntax");
                    }
                    choiceLoop = false;
                }
                else 
                {
                    Console.WriteLine("Not a Valid syntax");
                }

            }
        }
    }
        
}
