using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Movies : Item
    {
        public string Studio {  get; private set; }
        public string Producer { get; private set; }
        public string Director { get; private set; }
        public AgeRating AgeRating { get; private set; }
        public string Genre1 { get; private set; }
        public string Genre2 { get; private set; }

        public Movies(string name, string description, ItemCategory category, int price, int qunatity, string studio, string producer, string director, AgeRating ageRating, string genre1, string genre2)
           : base(name, description, category, price, qunatity)
        {
            Studio = studio;
            Producer = producer;
            Director = director;
            AgeRating = ageRating;
            Genre1 = genre1;
            Genre2 = genre2;
        }
    }
   
    public enum AgeRating
    {
        G,
        PG,
        PG13,
        R,
        NC17
    }
}
