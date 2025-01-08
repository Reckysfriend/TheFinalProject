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
        public int PageCount { get; private set; }
        public int PublishingYear { get; private set; }
        public string Genre1 {  get; private set; }
        public string Genre2 { get; private set; }




        public Book(string name, string description, Category category, int price, int qunatity,string author,int pageCount,int publishingYear,string genre1,string genre2) 
            :base(name,description,category,price,qunatity)


          

        {
            Author = author;  
            PageCount = pageCount;
            PublishingYear = publishingYear;
            Genre1 = genre1;
            Genre2 = genre2;
        }
    }
}
