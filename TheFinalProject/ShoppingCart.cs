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
        static public List<Item> ShoppingCartlist = new List<Item>();
        static public void AddItemToShoppingCart(Item item, int qunaitity)
        {
            item.Quantity = qunaitity;
            ShoppingCartlist.Add(item);
        }
        static public void Addtotalvalue()
        {
            int totalPrice = 0;  
            foreach (Item item in ShoppingCartlist)
            {
                int quantity = item.Quantity;
                int price = item.Price;
            }
        }
    }
        
}
