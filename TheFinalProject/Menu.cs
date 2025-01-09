using System;
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
            string originalMenuStr = "Welcome to amazon prime\n[1]Search item\n[2]View catalog\n[3]View cart\n[4]Exit Program";
            string menuStr = Admin.CreateMenuAdminString(originalMenuStr);
            bool menu = true;
            while (menu)
            {
                Console.WriteLine(menuStr);
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        menu = false;
                        break;
                    case 2:
                        Console.Clear();
                        ItemOrganisation.DisplayCatlog();
                        menu = false;
                        break;
                    case 3:
                        ShoppingCart.ViewCart();
                        menu = false;
                        break;
                    case 4:
                        menu = false;
                        Environment.Exit(0);
                        break;
                    case 5:
                        if (Admin.adminMode == false)
                        {
                            Admin.adminMode = true;
                        }
                        else if (Admin.adminMode == true) 
                        {
                            Admin.adminMode = false;
                        }
                        Console.Clear();
                        GoToMenu();
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;

                }
            }
        }
    }
}
