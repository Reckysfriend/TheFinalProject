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
        // Display current discount as a static double, this system only supports a single
        //discount as the same time hence making it static
        public static double currentDiscount = 0;
        //A bool to make sure we cannot accidently apply multiple discounts. 
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
                        //Loop through all items we have in stock and apply the discount
                        //to them.
                        foreach (var item in ItemOrganisation.itemList)
                        {
                            item.Price = item.Price * (1 - (discount / 100));
                        }
                        currentDiscount = discount;
                        //Make sure we cannot accidently apply a secound discount
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
            //Reverse the previous applied discount
            foreach (var item in ItemOrganisation.itemList)
            {
                item.Price = item.Price / (1 - (currentDiscount / 100));
            }
            //Allow us to apply a new discount
            hasDiscount= false;
            currentDiscount = 0;
        }
    }
}
