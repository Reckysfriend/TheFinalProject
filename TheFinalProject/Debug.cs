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
        int QuanityOfItemsToGenerate = 10;
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
        public void RunDebug2()
        {
            Item item1 = new Item("Apple", "It is a fruit", ItemCategory.Merchandise, 5, 0);
            Item item2= new Item("Pear", "It is a fruit", ItemCategory.Merchandise, 4, 15);
            Item item3 = new Item("Berry", "It is a berry", ItemCategory.Merchandise, 15, 100);
            Item item4 = new Item("Cucumber", "It is a vegetable", ItemCategory.Merchandise, 2, 1000);
            ItemOrganisation.itemList.Add(item1);
            ItemOrganisation.itemList.Add(item2);
            ItemOrganisation.itemList.Add(item3);
            ItemOrganisation.itemList.Add(item4);
        }
        

    }
}
