using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        
        public Item() { }

        public Item(string name, string description, ItemCategory category, int price, int qunatity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = qunatity;
        }
        public override string ToString()
        {
            return $"\n  {Name} {Price}$\n  {Quantity} in stock\n";
        }       
    }
}
