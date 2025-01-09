using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Debug
    {
        Item item = new Item();
        Random random = new Random();
        int QuanityOfItemsToGenerate = 1;
        public void RunDebug()
        {
            for (int i = 0; i < QuanityOfItemsToGenerate; i++)
            {
                string name = "Item #" + i;
                ItemCategory catagory = (ItemCategory)random.Next(0,6);
                string description = $"This is item #{i} and is sorted into the category: {catagory}";
                int price = random.Next(0,101);
                int quantity = random.Next(0, 1001);


                Item item = new Item(name,description,catagory,price,quantity);
                ItemOrganisation.itemList.Add(item);
            }
           
        }
        

    }
}
