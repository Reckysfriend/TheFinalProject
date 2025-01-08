using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class VideoGames : Item
    {
        public string PublishingStudio {  get; private set; }
        public string Platform { get; private set; }
        public string Genre1 { get; private set; }
        public string Genre2 { get; private set; }
        public VideoGames(string name, string description, Category category, int price, int qunatity, string publishingstudio, string platform, string genre1, string genre2)
            : base(name, description, category, price, qunatity)
        {
            PublishingStudio = publishingstudio;
            Platform = platform;
            Genre1 = genre1;
            Genre2 = genre2;
        }
    }

}
