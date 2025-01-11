using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Discount
    {
        public static double currentDiscount = 0;
        static bool hasDiscount = false;
        public static void GoToDiscountManager()
        {
            Console.WriteLine($"WHAT WOULD YOU LIKE TO DO (CURRENTY DISCOUNT: {currentDiscount}%)\n\n[1] SET NEW DISCOUNT" +
                $"\n[3] CLEAR CURRENT DISCOUNT\n\n[0] RETURN");
            bool loop = true;
            while ( loop )
            {
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch ( choice )
                {
                    case 0:
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 1:
                        Console.Clear();
                        loop = false;
                        SetDiscount();
                        break;
                    case 2:
                        Console.Clear();
                        loop = false;
                        ClearDiscount();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE ENTER A VALID MENU CHOICE\n");
                        break;


                }
            }
        }
        public static void SetDiscount()
        {
            if (hasDiscount == false)
            {
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine($"\tCURRENT DISCOUNT ({currentDiscount}%)\n\tWHAT WOULD YOU LIKE TO SET THE DISCOUNT TO? (%)");
                    Console.Write("\n\tCHOICE: ");
                    Double.TryParse(Console.ReadLine(), out double discount);
                    if (discount > 0)
                    {
                        foreach (var item in ItemOrganisation.itemList)
                        {
                            item.Price = item.Price * (1 - (discount / 100));
                        }
                        currentDiscount = discount;
                        hasDiscount = true;
                        Console.Clear();
                        GoToDiscountManager();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("PLEASE ENTER A VALID NUMBER\n");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("PLEASE REMOVE THE PREVIOUS DISCOUNT BEFORE APPLYING A NEW ONE");
                GoToDiscountManager();
            }
            
        }
        public static void ClearDiscount()
        {
            
            foreach (var item in ItemOrganisation.itemList)
            {
                item.Price = item.Price / (1 - (currentDiscount / 100));
            }
            hasDiscount= false;
            currentDiscount = 0;
        }
    }
}
