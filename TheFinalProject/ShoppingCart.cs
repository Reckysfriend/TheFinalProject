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
        public List<ShoppingCart> ShoppingCartlist = new List<ShoppingCart> ();
        ShoppingCart shoppingCart = new ShoppingCart ();
    }
    public void AddItemToShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart ();
            Item item = new Item();
            Console.WriteLine("What items would you like to add to your shoppingcart?");
            Console.WriteLine($"{item}");
            
            Console.WriteLine($"you have added{item} to your shoppingcart");
        }
}
