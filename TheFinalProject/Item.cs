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
        public int ID { get; private set; }
        
        public Item() { }

        public Item(string name, string description, ItemCategory category, double price, int qunatity)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = qunatity;
            nextID++;
            ID = nextID;
        }
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
            if (Quantity > 0) 
            {
                return $"\n  {Name} {Price}$\n  {Quantity} in stock\n ID: {ID.ToString("000000000")}" ;
            }
            else
            {
                return $"\n  {Name}\n OUT OF STOCK!\n";
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
                Console.Write($"What would you like to add [1]Name{itemName}\n[2]Description{description}\n[3]Category{category}\n[4]Price{itemPrice}\n[5]Quantity{itemQuantity}\n");
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
                                Console.WriteLine("An item already exists with this name please choose another name");
                            }
                            else
                            {
                                itemName = userInput;
                                hasName = true;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Type the desired description");
                        string userDescription = Console.ReadLine() ;
                        description = userDescription;
                        hasDescription = true;
                        break;
                    case 3:
                        bool categoryLoop = true;
                        while (categoryLoop)
                        {
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
                                userPrice = itemPrice;
                                hasPrice = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Aint nobody getting free stuff!");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Type Quantity of item");
                        bool subLoop = true;
                        while (subLoop)
                        {
                            Int32.TryParse(Console.ReadLine(), out int userQuantity);
                            if (userQuantity >= 0)
                            {
                                userQuantity = itemQuantity;
                                subLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You can't add no quantity!");
                            }
                        }
                        break;
                    case 6:
                        if (hasName == true && hasDescription == true &&  hasCategory == true && hasPrice == true && hasQuantity == true)
                        {
                            Item item = new Item(itemName, description, category, itemPrice, itemQuantity);
                            ItemOrganisation.itemList.Add(item);
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
