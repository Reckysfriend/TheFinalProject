using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        
        public Item() { }

        public Item(string name, string description, Category category, int price, int qunatity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = qunatity;
        }
        public override string ToString()
        {
            return $"--------------------\n{Name} ({Price}$)\n{Description}\n{Quantity} in stock\n--------------------";
        }
    }
}
