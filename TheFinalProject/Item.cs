using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheFinalProject
{
    internal class Item
    {
        static int nextID = 0;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //Makes sure ID cannot be edited outside of an items creation.
        public int ID { get; private set; }
        
        //Blank constructor incase of function reference
        public Item() { }

        //Constructor to make a fully fleded item
        public Item(string name, string description, ItemCategory category, double price, int qunatity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = qunatity;
            //Makes sure every item has a unique ID
            nextID++;
            ID = nextID;
        }
        //Constructor for quickly making a copy of an item when we move it to 
        //ShoppingCart
        public Item(Item other)
        {
            Name = other.Name;
            Description = other.Description;
            Category = other.Category;
            Price = other.Price;
            Quantity = other.Quantity;
            ID = other.ID;
        }
        public override string ToString()
        {
            //Override to write out the item in the catalog if it has stock
            if (Quantity > 0) 
            {
                return $"\n{Name}\nPRICE: {Price}$\nSTOCK:{Quantity}";
            }
            //Override to write out the item in the catalog if it has no stock
            else
            {
                return $"\n{Name}\n OUT OF STOCK!\n";
            }


        }
        static public void CreateItem()
        {
            //Adds a way to check which item properties have been added.
            bool hasName = false;
            bool hasDescription = false;
            bool hasCategory = false;
            bool hasPrice = false;
            bool hasQuantity = false;

            string itemName = "";
            string description = "";
            ItemCategory category = (ItemCategory)0;
            double itemPrice = 0;
            int itemQuantity = 0 ;
            bool menu = true;
            while (menu) 
            {
                //Changes the menu if the item is ready to be created. 
                if (hasName == true && hasDescription == true && hasCategory == true && hasPrice == true && hasQuantity == true)
                {
                    Console.Write($"WHAT WOULD YOU LIKE TO ADD \n[1]NAME: {itemName}\n[2]DESCRIPTION: {description}\n[3]CATEGORY: {category}\n[4]PRICE: {itemPrice}$\n[5]QUANTITY: {itemQuantity}x\n[6]ADD ITEM\nChOICE:");
                }
                else
                {
                    Console.Write($"WHAT WOULD YOU LIKE TO ADD \n[1]NAME: {itemName}\n[2]DESCRIPTION: {description}\n[3]CATEGORY: {category}\n[4]PRICE: {itemPrice}$\n[5]QUANTITY: {itemQuantity}x\nCHOICE:");
                }
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice) 
                {
                    case 1:
                        Console.WriteLine("PLEASE TYPE DESIRED NAME FOR ITEM");
                        string userInput = Console.ReadLine();
                        int i = 1;
                        foreach (var catalogItem in ItemOrganisation.itemList)
                        {
                            //Checks if the item already exsists by name to prevent
                            //Multiple items of the same name as they should be edited instead
                            if (catalogItem.Name == userInput)
                            {
                                Console.Clear();
                                Console.WriteLine("AN ITEM ALREADY EXISTS WITH THAT NAME PLEASE CHOOSE ANOTHER");
                            }
                            else
                            {
                                //Confirms we have set a name
                                itemName = userInput;
                                hasName = true;
                            }
                        }
                        Console.Clear();
                        break;
                    case 2:

                        Console.WriteLine("TYPE THE DESIRED DESCRIPTION");
                        string userDescription = Console.ReadLine() ;
                        description = userDescription;
                        hasDescription = true;
                        Console.Clear();
                        break;
                    case 3:
                        bool categoryLoop = true;
                        while (categoryLoop)
                        {
                            Console.WriteLine("TYPE DESIRED CATEGORY");
                            i = 1;
                            Console.WriteLine($"");
                            //Displays all values from the Enum "ItemCategory"
                            foreach (var name in Enum.GetNames(typeof(ItemCategory)))
                            {
                                Console.WriteLine($"[{i}]: {name}");
                                i++;
                            }
                            //Checks how many values there are for our menu choice
                            int amountOfCategories = Enum.GetValues(typeof(ItemCategory)).Length;
                            Int32.TryParse(Console.ReadLine(), out int categoryChoice);
                            categoryChoice -= 1;
                            //Checks if the choice is within the avilable options
                            if (categoryChoice >= 0 && categoryChoice <= amountOfCategories)
                            {
                                //Sets the category equal to the userinput's index - 1
                                category = (ItemCategory)categoryChoice;
                                hasCategory = true;
                                categoryLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("PLEASE ENTER A VALID CHOICE");
                            }
                        }
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("TYPE PRICE OF ITEM");
                        bool innerLoop = true;
                        while (innerLoop)
                        {
                            Double.TryParse(Console.ReadLine(), out double userPrice);
                            //Makes it so you cannot create a free item
                            if (userPrice > 0)
                            {
                                innerLoop = false;
                                itemPrice = userPrice;
                                hasPrice = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("ITEMS CANNOT BE FREE PLEASE TYPE ANOTHER PRICE");
                            }
                        }
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("TYPE QUANTITY OF ITEM");
                        bool subLoop = true;
                        while (subLoop)
                        {
                            Int32.TryParse(Console.ReadLine(), out int userQuantity);
                            //Allows you to create a item that has yet arrived in stock by setting
                            //its quantity to 0
                            if (userQuantity >= 0)
                            {
                                itemQuantity = userQuantity;
                                hasQuantity = true;
                                subLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("YOU CAN'T ADD NEGATIVE QUANTITY!");
                            }
                        }
                        Console.Clear();
                        break;
                    case 6:
                        //Checks that all variables for the item constructor are satisfied
                        //before atemptting to create it. 
                        if (hasName == true && hasDescription == true &&  hasCategory == true && hasPrice == true && hasQuantity == true)
                        {
                            Item item = new Item(itemName, description, category, itemPrice, itemQuantity);
                            ItemOrganisation.itemList.Add(item);
                            Console.Clear();
                            Console.WriteLine("YOU HAVE ADDED AN ITEM");
                        }
                        else
                        {
                            Console.Clear();
                            menu = false;
                            CreateItem();
                        }
                        menu = false;
                        break;
                    case 7:
                        Menu.GoToMenu();
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("THIS IS NOT A VALID INPUT");
                        menu = false;
                        break;
                }
            }

        }
    }
}
