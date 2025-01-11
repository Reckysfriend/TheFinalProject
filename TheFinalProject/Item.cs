using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Item
    {
        static int nextID = 0;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ID { get; private set; }
        
        public Item() { }

        public Item(string name, string description, ItemCategory category, int price, int qunatity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = qunatity;
            nextID++;
            ID = nextID;
        }
        public Item(Item other)
        {
            Name = other.Name;
            Description = other.Description;
            Category = other.Category;
            Price = other.Price;
            Quantity = other.Quantity;
            ID = other.ID;
        }
        public override string ToString()
        {
            if (Quantity > 0) 
            {
                return $"\n{Name}\nPRICE: {Price}$\nSTOCK:{Quantity}";
            }
            else
            {
                return $"\n{Name}\n OUT OF STOCK!\n";
            }


        }       
    }
}
