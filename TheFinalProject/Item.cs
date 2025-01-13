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
                if (hasName == true && hasDescription == true && hasCategory == true && hasPrice == true && hasQuantity == true)
                {
                    Console.Write($"What would you like to add \n[1]Name: {itemName}\n[2]Description: {description}\n[3]Category: {category}\n[4]Price: {itemPrice}$\n[5]Quantity: {itemQuantity}x\n[6]Add item\nChoice:");
                }
                else
                {
                    Console.Write($"What would you like to add \n[1]Name: {itemName}\n[2]Description: {description}\n[3]Category: {category}\n[4]Price: {itemPrice}$\n[5]Quantity: {itemQuantity}x\nChoice:");
                }
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                switch (menuChoice) 
                {
                    case 1:
                        Console.WriteLine("Please type desired name for item");
                        string userInput = Console.ReadLine();
                        int i = 1;
                        foreach (var catalogItem in ItemOrganisation.itemList)
                        {
                            if (catalogItem.Name == userInput)
                            {
                                Console.Clear();
                                Console.WriteLine("An item already exists with this name please choose another name");
                            }
                            else
                            {
                                itemName = userInput;
                                hasName = true;
                            }
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Type the desired description");
                        string userDescription = Console.ReadLine() ;
                        description = userDescription;
                        hasDescription = true;
                        Console.Clear();
                        break;
                    case 3:
                        bool categoryLoop = true;
                        while (categoryLoop)
                        {
                            Console.WriteLine("Type desired category");
                            i = 1;
                            Console.WriteLine($"");
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
                                category = (ItemCategory)categoryChoice;
                                hasCategory = true;
                                categoryLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid choice");
                            }
                        }
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Type price of item");
                        bool innerLoop = true;
                        while (innerLoop)
                        {
                            Double.TryParse(Console.ReadLine(), out double userPrice);
                            if (userPrice > 0)
                            {
                                innerLoop = false;
                                itemPrice = userPrice;
                                hasPrice = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Aint nobody getting free stuff!");
                            }
                        }
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Type Quantity of item");
                        bool subLoop = true;
                        while (subLoop)
                        {
                            Int32.TryParse(Console.ReadLine(), out int userQuantity);
                            if (userQuantity >= 0)
                            {
                                itemQuantity = userQuantity;
                                hasQuantity = true;
                                subLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You can't add no quantity!");
                            }
                        }
                        Console.Clear();
                        break;
                    case 6:
                        if (hasName == true && hasDescription == true &&  hasCategory == true && hasPrice == true && hasQuantity == true)
                        {
                            Item item = new Item(itemName, description, category, itemPrice, itemQuantity);
                            ItemOrganisation.itemList.Add(item);
                            Console.Clear();
                            Console.WriteLine("You have added an item");
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
                        Console.WriteLine("This is not a valid input");
                        menu = false;
                        break;
                }
            }

        }
    }
}
