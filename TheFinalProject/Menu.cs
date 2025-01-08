using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Menu
    {
        public void TestMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Welcome to amazon prime\n[1]Search item\n[2]View catalog\n[3]View cart\n[4]enter Admin Mode\n[5]Exit Program");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        menu = false;
                        break;
                    case 2:
                        menu = false;
                        break;
                    case 3:
                        menu = false;
                        break;
                    case 4:
                        menu = false;
                        break;
                    case 5:
                        menu = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;

                }
            }
        }
    }
}
