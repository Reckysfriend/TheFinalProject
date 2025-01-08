using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Book : Item
    {
        public string Author { get; private set; }

        public Book(string name, string description, Category category, int price, int qunatity) :  base(name,description,category,price,qunatity)
        {
            Author = "";  
        }
    }
}
