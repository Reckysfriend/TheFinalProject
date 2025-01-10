using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class ItemOrganisation
    {
        static public List<Item> itemList = new List<Item>();


        static public void DisplayCatlog()
        {
            string input = "ENTER THE # OF THE ITEM YOU WISH TO VIEW (0 TO RETURN):";
            string adminStr = Admin.CreateAdminString(input);
            bool choiceLoop = true;
            int i = 1;
            foreach (Item item in ItemOrganisation.itemList)
            {
                Console.WriteLine($"====================\n\t[{i}]\n{item}\n====================");
                i++;
            }
            while ( choiceLoop )
            {               
                Console.Write(adminStr);
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
                    GoToItem(indexChoice - 1);
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
                Console.WriteLine($"{name} ({price}$)\n\n\t\tCategory: {category}" +
                               $"\n\n\t\tDescription: {description})\n[1]Edit item   [2]Remove item   [3] Return");
                choiceLoop = true;
                while (choiceLoop)
                {
                    Int32.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ItemEdit(itemList[index], index);
                            break;
                        case 2:
                            itemList.RemoveAt(index);
                            DisplayCatlog();
                        break;
                        case 3:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid menu choice\n");
                        break;
                }
                }

                        
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
                                else if (userInput <= quantity)
                                {
                                    ShoppingCart.AddItemToShoppingCart(itemList[index], userInput);
                                    subChoice = false;
                                    Menu.GoToMenu();                                  
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
        static void ItemEdit(Item item, int index)
        {
           
            bool choiceLoop = true;
            bool subLoop = false;
            while (choiceLoop)
            {
                Console.WriteLine("General:\n[1] Name [2] Descrpition [3] Category [4] Price [5] Stock\n\n[6] Return");
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Current name: {item.Name}");
                        Console.Write("\nNew name:");
                        string newName = Console.ReadLine();
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"Confirm name override\n\nOld Name: {item.Name}\nNew Name: {newName}\n\n[1] Replace   [2] Return");
                            Int32.TryParse(Console.ReadLine(), out int subChoice);
                            switch (subChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    itemList[index].Name = newName;
                                    subLoop = false;
                                    break;
                                case 2:
                                    subLoop = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid choice\n");
                                    break;
                            }
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine($"Current Description: {item.Description}");
                        Console.Write("\nNew Description:");
                        string newDescription = Console.ReadLine();
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"Confirm name override\n\nOld Description: {item.Description}\nNew Description: " +
                                $"{newDescription}\n\n[1] Replace   [2] Return");
                            Int32.TryParse(Console.ReadLine(), out int subChoice);
                            switch (subChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    itemList[index].Description = newDescription;
                                    subLoop = false;
                                    break;
                                case 2:
                                    subLoop = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid choice\n");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        bool categoryLoop = true;
                        subLoop = true;
                        while (categoryLoop)
                        {
                            int i = 1;
                            Console.WriteLine($"Current Category: {item.Category}");
                            foreach (var name in Enum.GetNames(typeof(ItemCategory)))
                            {
                                Console.WriteLine($"[{i}]: {name}");
                                i++;
                            }
                            int amountOfCategories = Enum.GetValues(typeof(ItemCategory)).Length;
                            Int32.TryParse(Console.ReadLine(), out int categoryChoice);
                            categoryChoice -= 1;
                            if (categoryChoice > 0 && categoryChoice <= amountOfCategories)
                            {
                                categoryLoop = false;
                                while (subLoop)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Confirm name override\n\nOld Category: {item.Category}\nNew Category: " +
                                        $"{(ItemCategory)categoryChoice}\n\n[1] Replace   [2] Return");
                                    Int32.TryParse(Console.ReadLine(), out int subChoice);
                                    switch (subChoice)
                                    {
                                        case 1:
                                            Console.Clear();
                                            itemList[index].Category = (ItemCategory)categoryChoice;
                                            subLoop = false;
                                            break;
                                        case 2:
                                            categoryLoop = true;
                                            subLoop = false;
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Please enter a valid choice\n");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid choice");
                            }
                        }
                        break;
                    case 4:
                        int newPrice = 0;
                        Console.WriteLine($"Current Price: {item.Price}$");
                        Console.Write("\nNew Price:");
                        subLoop = true;
                        while (subLoop)
                        {
                            Int32.TryParse(Console.ReadLine(), out newPrice);
                            if (newPrice > 0)
                            {
                                subLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid number");
                            }
                        }
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"Confirm price override\n\nOld Price: {item.Price}$\nNew Price: " +
                                $"{newPrice}$\n\n[1] Replace   [2] Return");
                            Int32.TryParse(Console.ReadLine(), out int subChoice);
                            switch (subChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    itemList[index].Price = newPrice;
                                    subLoop = false;
                                    break;
                                case 2:
                                    subLoop = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid choice\n");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        int newStock = 0;
                        Console.WriteLine($"Current Stock: {item.Quantity}");
                        Console.Write("\nNew Stock:");
                        subLoop = true;
                        while (subLoop)
                        {
                            Int32.TryParse(Console.ReadLine(), out newStock);
                            if (newStock > 0)
                            {
                                subLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid number");
                            }
                        }
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"Confirm stock override\n\nOld Stock: {item.Quantity}\nNew Stock: " +
                                $"{newStock}\n\n[1] Replace   [2] Return");
                            Int32.TryParse(Console.ReadLine(), out int subChoice);
                            switch (subChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    itemList[index].Quantity = newStock;
                                    subLoop = false;
                                    break;
                                case 2:
                                    subLoop = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid choice\n");
                                    break;
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        ItemEdit(item, index);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid menu choice");
                        break;
                }
            }
        }
    }
}
