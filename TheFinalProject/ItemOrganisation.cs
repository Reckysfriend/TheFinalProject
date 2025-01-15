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

        //The static list that holds all our items in our catalog
        static public List<Item> itemList = new List<Item>();


        static public void DisplayCatelog()
        {
            string input = "ENTER THE # OF THE ITEM YOU WISH TO VIEW (0 TO RETURN):";
            //Displays a different string if you ar ein adminMode.
            string adminStr = Admin.CreateAdminString(input);
            bool choiceLoop = true;
            int i = 1;
            string catalogStr = "";
            //Displays all items in catalog
            foreach (Item item in itemList)
            {
                Console.Write($"+--------------------+\n\t[{i}]{item}\n+--------------------+\n");
                i++;
            }
            while ( choiceLoop )
            {               
                Console.Write(adminStr);
                Int32.TryParse( Console.ReadLine(), out int indexChoice);
                //If you give it a value of 0 return
                if(indexChoice == 0)
                {
                    Console.Clear();
                    choiceLoop = false;
                    Menu.GoToMenu();
                }
                //Checks if the usersinput is a valid choice and goes to the items
                else if(indexChoice >= 0 && indexChoice <= itemList.Count)
                {
                    Console.Clear();
                    choiceLoop = false;
                    GoToItem(indexChoice - 1);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid choice");
                    DisplayCatlog();
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
            //Only show the editorial options if you are in adminMode
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
                            DisplayCatelog();
                            break;
                        case 1:
                            Console.Clear();
                            ItemEdit(itemList[index], index);
                            break;
                        case 2:
                            itemList.RemoveAt(index);
                            DisplayCatelog();
                        break;                  
                    default:
                        Console.Clear();
                        Console.WriteLine("PLEASE ENTER A VALID MENU CHOICE\n");
                        break;
                }
                }                      
            }
            //Otherwise show the normal user menu.
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
                            DisplayCatelog();
                            break;
                        case 1:
                            //Only allows you to add a item to cart if it has stock
                            if (quantity != 0)
                            {
                                bool subChoice = true;
                                while (subChoice)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\t\tHOW MANY {name} WOULD YOU LIKE TO BUY? ({quantity} IN STOCK)");
                                    Console.Write("\n\n\t\tENTER 0 TO RETURN: ");
                                    Int32.TryParse(Console.ReadLine(), out int userInput);
                                    //Returns to the item page if you enter 0
                                    if (userInput == 0)
                                    {
                                        subChoice = false;
                                        Console.Clear();
                                        GoToItem(index);
                                    }
                                    //Prevents you from adding more stock than there is
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
        //Allows you to replace any value except ID on a already exsisting item.
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
        //Allows you to sort the catalog with the use of a bubblesort
        public static void SortList()
        {
            int max = itemList.Count - 1;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("HOW DO YOU WANNA SORT THE CATALOG?\n\t[1] NAME  [2] CATEGORY  [3] STOCK  [4] PRICE  [5] RETURN");
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        max = itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                int compare = itemList[j].Name.CompareTo(itemList[j + 1].Name);
                                if (compare > 0)
                                {
                                    Item temp = itemList[j];
                                    itemList[j] = itemList[j + 1];
                                    itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 2:
                        max = itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                int compare = itemList[j].Category.CompareTo(itemList[j + 1].Category);
                                if (compare > 0)
                                {
                                    Item temp = itemList[j];
                                    itemList[j] = itemList[j + 1];
                                    itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 3:
                        max = itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                if (itemList[j].Quantity > itemList[j + 1].Quantity)
                                {
                                    Item temp = itemList[j];
                                    itemList[j] = itemList[j + 1];
                                    itemList[j + 1] = temp;
                                }

                            }

                        }
                        Console.Clear();
                        loop = false;
                        Menu.GoToMenu();
                        break;
                    case 4:
                        max = itemList.Count - 1;
                        for (int i = 0; i < max; i++)
                        {
                            int left = max - i;
                            for (int j = 0; j < left; j++)
                            {
                                if (itemList[j].Price > itemList[j + 1].Price)
                                {
                                    Item temp = itemList[j];
                                    itemList[j] = itemList[j + 1];
                                    itemList[j + 1] = temp;
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
