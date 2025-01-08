using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Food : Item
    {
        public string Type { get; private set; }
        public Flavors Flavor { get; private set; }

        public Food(string name, string description, Catagory catagory, int price, int qunatity)
            : base(name, description, catagory, price, qunatity)
        {

        }
    }
}
