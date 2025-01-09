using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class ItemOrganisation
    {
        static public List<Item> itemList = new List<Item>();

        static public void DisplayCatlog()
        {
            int i = 1;
            foreach (Item item in ItemOrganisation.itemList)
            {
                Console.WriteLine($"#{i} {item}");
                i++;
            }
        }
    }
}
