﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Menu
    {
        static public void GoToMenu()
        {
            //Changes menu string depending on if adminMode is on or off
            string menuStr = "WELCOME TO CHEAP CHEATING SHOPPERS!\n\n[1] VIEW CATALOG\n[2] VIEW CART\n[3] SORT CATALOG";
            if (Admin.adminMode == true)
            {
                menuStr = "ADMIN MODE\n\n" + menuStr + "\n\n[4] ADD ITEM\n[5] MANAGE DISCOUNTS\n[6] EXIT ADMIN MODE\n\n[0] EXIT PROGRAM";
            }
            else
            {
                menuStr = menuStr + "\n\n[4] ENTER ADMIN MODE\n\n[0] EXIT PROGRAM";
            }
            bool menu = true;
            while (menu)
            {
                Console.WriteLine(menuStr);
                Console.Write("\nCHOICE: ");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 0:
                        menu = false;
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        ItemOrganisation.DisplayCatelog();
                        menu = false;
                        break;
                    case 2:
                        Console.Clear();
                        ShoppingCart.ViewCart();
                        menu = false;
                        break;
                    case 3:

                        Console.Clear();
                        ItemOrganisation.SortList();
                        menu = false;
                        break;
                    case 4:
                        //Only accessible if adminMode is on
                        if (Admin.adminMode == true)
                        {
                            Console.Clear();
                            Item.CreateItem();
                        }
                        //If adminMode is off, enable it
                        else
                        {
                            Console.Clear();
                            Admin.adminMode = true;
                            GoToMenu();
                        }
                        break;
                    case 5:
                        //Only accessible if adminMode is on
                        if (Admin.adminMode == true)
                        {
                            Console.Clear();
                            Discount.GoToDiscountManager();
                        }
                        Console.Clear();
                        GoToMenu();
                        break;
                    case 6:
                        //Only accessible if adminMode is on. Turns off adminMode
                        if (Admin.adminMode == true)
                        {
                            Console.Clear();
                            Admin.adminMode = false;
                            GoToMenu();
                        }
                        Console.Clear();
                        GoToMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("INVALID MENU CHOICE\n");
                        break;

                }
            }
        }
    }
}
