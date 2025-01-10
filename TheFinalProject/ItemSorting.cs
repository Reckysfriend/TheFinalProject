using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class ItemSorting
    {
       
        static public string sortedListString;
        public static void SortList()
        {
            int max = ItemOrganisation.itemList.Count - 1;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("How do you wanna sort the catalog?\n\t[1] Name  [2] Category  [3] Stock  [4] Price  [5] Return");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        max = ItemOrganisation.itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                int compare = ItemOrganisation.itemList[j].Name.CompareTo(ItemOrganisation.itemList[j + 1].Name);
                                if (compare > 0)
                                {
                                    Item temp = ItemOrganisation.itemList[j];
                                    ItemOrganisation.itemList[j] = ItemOrganisation.itemList[j + 1];
                                    ItemOrganisation.itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 2:
                        max = ItemOrganisation.itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                int compare = ItemOrganisation.itemList[j].Category.CompareTo(ItemOrganisation.itemList[j + 1].Category);
                                if (compare > 0)
                                {
                                    Item temp = ItemOrganisation.itemList[j];
                                    ItemOrganisation.itemList[j] = ItemOrganisation.itemList[j + 1];
                                    ItemOrganisation.itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 3:
                        max = ItemOrganisation.itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                if (ItemOrganisation.itemList[j].Quantity > ItemOrganisation.itemList[j + 1].Quantity)
                                {
                                    Item temp = ItemOrganisation.itemList[j];
                                    ItemOrganisation.itemList[j] = ItemOrganisation.itemList[j + 1];
                                    ItemOrganisation.itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 4:
                        max = ItemOrganisation.itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                if (ItemOrganisation.itemList[j].Price > ItemOrganisation.itemList[j + 1].Price)
                                {
                                    Item temp = ItemOrganisation.itemList[j];
                                    ItemOrganisation.itemList[j] = ItemOrganisation.itemList[j + 1];
                                    ItemOrganisation.itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 5:
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid sorting choice.\n");
                        break;
                }
            }
            Console.Clear();
            
        }
    }
}
