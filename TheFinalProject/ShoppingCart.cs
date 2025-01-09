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
            foreach (Item item in ShoppingCartList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Quantity);
            }
            Console.ReadLine();
        }
    }
        
}
