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
        //Enter amount of random item you wish to generate below
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
            //Change the values of the items you wanna generate
            Item item1 = new Item("Apple", "We don't really sell fruit", ItemCategory.Merchandise, 5, 0);
            Item item2= new Item("Arkham Horror LCG", "A deckbuilding mystery adventure card game.", ItemCategory.BoardGames, 60, 15);
            Item item3 = new Item("Skyrim", "The mordern RPG Godfather", ItemCategory.VideoGames, 30, 100);
            Item item4 = new Item("Percy Jackson: The Lightning Theif", "A greek childhood classic", ItemCategory.Book, 12, 1000);
            ItemOrganisation.itemList.Add(item1);
            ItemOrganisation.itemList.Add(item2);
            ItemOrganisation.itemList.Add(item3);
            ItemOrganisation.itemList.Add(item4);
        }
        

    }
}
