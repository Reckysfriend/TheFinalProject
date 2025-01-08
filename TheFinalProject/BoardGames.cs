using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class BoardGames : Item
    {
        public string Type { get; private set; }
        public string Genre1 { get; private set; }
        public string Genre2 { get; private set; }
        public string Publisher { get;private set; }
        public string PlayerCount { get; private set; }
        public BoardGames(string name, string description, Category category, int price, int qunatity, string type, string genre1, string genre2, string publisher, string playercount)
            : base(name, description, category, price, qunatity)
        {
            Type = type;
            Genre1 = genre1;
            Genre2 = genre2;
            Publisher = publisher;
            PlayerCount = playercount;
        }

    }
}
