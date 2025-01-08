using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Accessories : Item
    {
        public AccessoryType Type;

        public Accessories(string name, string description, ItemCategory category, int price, int qunatity, AccessoryType type)
        :base(name, description, category, price, qunatity)
        {
            Type = type;
        }
    }
    public enum AccessoryType
    {
        Cardpacks,
        Sleeves,
        Bookmarks,
        Dice,
        Playmats,
    }
}
