using System;
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
         static public List<Item> ShoppingCartList = new List<Item>();
         static public void AddItemToShoppingCart(Item item)
        {
            if (ShoppingCartList.Count != 0)
            {
                foreach (var cartitem in ShoppingCartList)
                {
                    if (cartitem.ID == item.ID)
                    {
                        cartitem.Quantity += item.Quantity;
                    }
                    else
                    {
                        ShoppingCartList.Add(item);
                    }
                }
            }
            else
            {
                ShoppingCartList.Add(item);
            }
           
                     
        }
         static public double Addtotalvalue()
        {
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
            double totalprice = Addtotalvalue();
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
                        Console.WriteLine("Please pick an existing option");
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
                        if (ShoppingCartList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no items in the cart to purchase");
                            menu = false;
                            ViewCart();
                        }
                        else
                        {
                            ShoppingCartList.Clear();
                            Console.Clear();
                            Console.WriteLine("Thank you for your purchase");
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
                        Console.WriteLine("Please pick an existing option");
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
                Console.WriteLine("[1]Remove item   [2]Clear Cart");
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
                        if (ShoppingCartList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no items to remove");
                        }
                        else
                        {
                            Console.Clear();
                            foreach (var cartItem in ShoppingCartList)
                            {
                                foreach (var catalogItem in ItemOrganisation.itemList)
                                if (catalogItem.ID == cartItem.ID)
                                {
                                    catalogItem.Quantity += cartItem.Quantity;
                                }
                            }
                            ShoppingCartList.Clear();
                            Console.WriteLine("You just cleared the cart");
                        }
                        ViewCart();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("This is not a valid option");
                        break;
                }
            }
        }
         static public void RemoveSpecificItem()
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
                    ViewCart();
                }
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
                            foreach (var catalogItem in ItemOrganisation.itemList)
                            {
                                if (catalogItem.ID == selectedItem.ID)
                                {
                                    catalogItem.Quantity += quantityToRemove;
                                }
                            }   
                            ShoppingCartList.RemoveAt(indexChoice - 1);
                        }
                        else
                        {
                            foreach (var catalogItem in ItemOrganisation.itemList)
                            {
                                if (catalogItem.ID == selectedItem.ID)
                                {
                                    catalogItem.Quantity += quantityToRemove;
                                }
                            }
                            ShoppingCartList[indexChoice - 1].Quantity -= quantityToRemove;
                        }
                        Console.Clear();
                        Console.WriteLine($"You removed {quantityToRemove}x {selectedItem.Name} from the cart!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not a valid option");
                        ViewCart();
                    }
                    choiceLoop = false;
                    ViewCart();
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid option");
                    ViewCart();
                }

            }
        }
    }
        
}
