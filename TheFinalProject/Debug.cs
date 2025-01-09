using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Debug
    {
        public List<Item> itemList = new List<Item>();    
        Item item = new Item();
        Random random = new Random();
        int QuanityOfItemsToGenerate = 100;
        public void RunDebug()
        {
            for (int i = 0; i < QuanityOfItemsToGenerate; i++)
            {
                string name = "Item #" + i;
                Catagory catagory = (Catagory)random.Next(0,6);
                string description = $"This is item #{i} and is sorted into the category: {catagory}";
                int price = random.Next(0,101);
                int quantity = random.Next(0, 1001);


                Item item = new Item(name,description,catagory,price,quantity);
                itemList.Add(item);
            }
            foreach (Item item in itemList)
            {
                Console.WriteLine(item);
            }
        }
        

    }
}
