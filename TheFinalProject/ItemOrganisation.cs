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
        static public string sortedListString;
        static public List<Item> itemList = new List<Item>();


        static public void DisplayCatlog()
        {
            string input = "ENTER THE # OF THE ITEM YOU WISH TO VIEW (0 TO RETURN):";
            string adminStr = Admin.CreateAdminString(input);
            bool choiceLoop = true;
            int i = 1;
            string catalogStr = "";
            foreach (Item item in itemList)
            {
                Console.Write($"+--------------------+\n\t[{i}]{item}\n+--------------------+\n");
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
                    Console.Clear();
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
            double price = itemList[index].Price;
            int quantity = itemList[index].Quantity;
            int id = itemList[index].ID;
            bool choiceLoop = true;
            if (Admin.adminMode == true )
            {
                
                choiceLoop = true;
                while (choiceLoop)
                {
                    Console.WriteLine($"{name}\nID: {id.ToString("00000")}\nDESCRIPTION: {description}\n\n" +
                        $"PRICE: {price}$\nCATEGORY: {category}\nSTOCK: " +
                    $"{quantity}\n\n\t[1]EDIT   [2]REMOVE   [0] RETURN");
                    Int32.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            choiceLoop = false;
                            DisplayCatlog();
                            break;
                        case 1:
                            Console.Clear();
                            ItemEdit(itemList[index], index);
                            break;
                        case 2:
                            itemList.RemoveAt(index);
                            DisplayCatlog();
                        break;                  
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE ENTER A VALID MENU CHOICE\n");
                        break;
                }
                }                      
            }
            else
            {
                Console.WriteLine($"{name}\nDESCRIPTION: {description}\n\nPRICE: {price}$\nCATEGORY: {category}\nSTOCK: " +
                    $"{quantity}\n\n\t[1]ADD TO CART [0] RETURN");
                choiceLoop = true;
                while (choiceLoop)
                {
                    Int32.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 0:
                            choiceLoop = false;
                            DisplayCatlog();
                            break;
                        case 1:
                            if (quantity != 0)
                            {
                                bool subChoice = true;
                                while (subChoice)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\t\tHOW MANY {name} WOULD YOU LIKE TO BUY? ({quantity} IN STOCK)");
                                    Console.Write("\n\n\t\tENTER 0 TO RETURN: ");
                                    Int32.TryParse(Console.ReadLine(), out int userInput);
                                    if (userInput == 0)
                                    {
                                        subChoice = false;
                                        Console.Clear();
                                        GoToItem(index);
                                    }
                                    else if (userInput <= quantity)
                                    {
                                        Console.Clear();
                                        Item cartItem = new (itemList[index]);
                                        cartItem.Quantity = userInput;
                                        itemList[index].Quantity -= userInput;
                                        ShoppingCart.AddItemToShoppingCart(cartItem);                                       
                                        subChoice = false;
                                        Menu.GoToMenu();
                                    }
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("SORRY THIS ITEM IS OUT OF STOCK");
                                choiceLoop = false;
                                GoToItem(index);
                            }
                           
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
                Console.WriteLine("GENERAL:\n[1] NAME [2] DESCRIPTION [3] CATEGORY [4] PRICE [5] STOCK\n\n[0] RETURN");
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        GoToItem(index);
                        break;
                    case 1:
                        Console.WriteLine($"CURRENT NAME: {item.Name}");
                        Console.Write("\nNEW NAME:");
                        string newName = Console.ReadLine();
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"CONFIRM NAME OVERRIDE\n\nOLD NAME: {item.Name}\nNEW NAME: {newName}\n\n[1] REPLACE   [2] RETURN");
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
                                    Console.WriteLine("PLEASE ENTER A VALID CHOICE\n");
                                    break;
                            }
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine($"CURRENT DESCRIPTION: {item.Description}");
                        Console.Write("\nNEW DESCRIPTION:");
                        string newDescription = Console.ReadLine();
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"CONFIRM NAME OVERRIDE\n\nOLD DESCRIPTION: {item.Description}\nNEW DESCRIPTION: " +
                                $"{newDescription}\n\n[1] REPLACE   [2] RETURN");
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
                                    Console.WriteLine("PLEASE ENTER A VALID CHOICE\n");
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
                            Console.WriteLine($"CURRENT CATEFORY: {item.Category}");
                            foreach (var name in Enum.GetNames(typeof(ItemCategory)))
                            {
                                Console.WriteLine($"[{i}]: {name}");
                                i++;
                            }
                            int amountOfCategories = Enum.GetValues(typeof(ItemCategory)).Length;
                            Int32.TryParse(Console.ReadLine(), out int categoryChoice);
                            categoryChoice -= 1;
                            if (categoryChoice >= 0 && categoryChoice <= amountOfCategories)
                            {
                                categoryLoop = false;
                                while (subLoop)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"CONFIRM NAME OVERRIDE\n\nOLD CATEGORY: {item.Category}\nNEW CATEGORY: " +
                                        $"{(ItemCategory)categoryChoice}\n\n[1] REPLACE   [2] RETURN");
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
                                            Console.WriteLine("PLEASE ENTER A VALID CHOICE\n");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("PLEASE ENTER A VALID CHOICE");
                            }
                        }
                        break;
                    case 4:
                        int newPrice = 0;
                        Console.WriteLine($"CURRENT PRICE: {item.Price}$");
                        Console.Write("\nNEW PRICE:");
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
                                Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                            }
                        }
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"CONFIRM PRICE OVERRIDE\n\nOLD PRICE: {item.Price}$\nNEW PRICE: " +
                                $"{newPrice}$\n\n[1] REPLACE   [2] RETURN");
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
                                    Console.WriteLine("PLEASE ENTER A VALID CHOICE\n");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        int newStock = 0;
                        Console.WriteLine($"CURRENT STOCK: {item.Quantity}");
                        Console.Write("\nNEW STOCK:");
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
                                Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                            }
                        }
                        subLoop = true;
                        while (subLoop)
                        {
                            Console.Clear();
                            Console.WriteLine($"CONFFIRM STOCK OVERRIDE\n\nOLD STOCK: {item.Quantity}\nNEW STOCK: " +
                                $"{newStock}\n\n[1] REPLACE   [2] RETURN");
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
                                    Console.WriteLine("PLEASE ENTER A VALID CHOICE\n");
                                    break;
                            }
                        }
                        break;
                   
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE ENTER A VALID MENU CHOICE");
                        break;
                }
            }
        }
        public static void SortList()
        {
            int max = ItemOrganisation.itemList.Count - 1;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("HOW DO YOU WANNA SORT THE CATALOG?\n\t[1] NAME  [2] CATEGORY  [3] STOCK  [4] PRICE  [5] RETURN");
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
                        Console.WriteLine("PLEASE ENTER A VALID SORTING CHOICE.\n");
                        break;
                }
            }
            Console.Clear();

        }
    }
}
