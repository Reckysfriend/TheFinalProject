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
            bool choiceLoop = true;
            int i = 1;
            foreach (Item item in ItemOrganisation.itemList)
            {
                Console.WriteLine($"====================\n\t[{i}]\n{item}\n====================");
                i++;
            }
            while ( choiceLoop )
            {
                Console.Write("ENTER THE # OF THE ITEM YOU WISH TO VIEW (0 TO RETURN): ");
                Int32.TryParse( Console.ReadLine(), out int indexChoice);
                if(indexChoice == 0)
                {
                    Console.Clear();
                    choiceLoop = false;
                    Menu.GoToMenu();
                }
                else if(indexChoice >= 0 && indexChoice <= itemList.Count)
                {
                    choiceLoop = false;
                    ItemOrganisation.GoToItem(indexChoice - 1);
                }
                
            }
        }
        static public void GoToItem(int index)
        {
            string name = itemList[index].Name;
            string description = itemList[index].Description;
            ItemCategory category = itemList[index].Category;
            int price = itemList[index].Price;
            int quantity = itemList[index].Quantity;
            bool choiceLoop = true;
            Console.Clear();
            if (Admin.adminMode == true )
            {

            }
            else
            {
                Console.WriteLine($"\t\t=======================\n\t\t| [1] Add to Cart     | \n\t\t|                     |\n" +
                                $"\t\t| [2] Return          |\t\t\n\t\t=======================\n\n\t\t{name} ({price}$)\n\n\t\tCategory: {category}" +
                                $"\n\n\t\tDescription: {description})");
                choiceLoop = true;
                while (choiceLoop)
                {
                    Int32.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            bool subChoice = true;
                            while (subChoice)
                            {
                                Console.Clear();
                                Console.WriteLine($"\t\tHow many {name} would you like to buy? ({quantity} in stock)");
                                Console.Write("\n\n\t\tEnter 0 to return: ");
                                Int32.TryParse(Console.ReadLine(), out int userInput);
                                if (userInput == 0)
                                {
                                    subChoice = false;
                                    GoToItem(index);
                                }
                                else
                                {
                                    //Add item to cart passing the item and quanity of items.
                                    subChoice = false;
                                }
                            }
                            break;
                        case 2:
                            choiceLoop = false;
                            DisplayCatlog();
                            break;
                    }
            
                        
                }
            }

        }
    }
}
