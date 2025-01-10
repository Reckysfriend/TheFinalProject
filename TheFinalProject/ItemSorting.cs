using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class ItemSorting
    {
        static public string sortedListString; 
        static public List<Accessories> accesoriesList = new List<Accessories>();
        static public List<BoardGames> boardGamesList = new List<BoardGames>();
        static public List<Book> booksList = new List<Book>();
        static public List<Merchandise> merchandiseList = new List<Merchandise>();
        static public List<Movies> moviesList = new List<Movies>();
        static public List<VideoGames> videoGamesList = new List<VideoGames>();
        static public void SortItem()
        {
            Console.WriteLine($"Item list count: {ItemOrganisation.itemList.Count}");
            foreach (var item in ItemOrganisation.itemList)
            {
                Console.WriteLine($"Item type: {item.GetType()}");
                if (item is Accessories accessories)
                {
                    accesoriesList.Add(accessories);
                }
                if (item is BoardGames boardGames)
                {
                    boardGamesList.Add(boardGames);
                }
                if (item is Book books)
                {
                    booksList.Add(books);
                }
                if (item is Merchandise merchandise)
                {
                    merchandiseList.Add(merchandise);
                }
                if (item is Movies movies)
                {
                    moviesList.Add(movies);
                }
                if (item is VideoGames videoGames)
                {
                    videoGamesList.Add(videoGames);
                }
            }
            foreach (var item in ItemOrganisation.itemList)
            {
                if (item is Accessories accessories)
                {
                    accesoriesList.Add(accessories);
                }
                if (item is BoardGames boardGames)
                {
                    boardGamesList.Add(boardGames);
                }
                if (item is Book books)
                {
                    booksList.Add(books);
                }
                if (item is Merchandise merchandise)
                {
                    merchandiseList.Add(merchandise);
                }
                if (item is  Movies movies)
                {
                    moviesList.Add(movies);
                }
                if (item is VideoGames videoGames)
                {
                    videoGamesList.Add(videoGames);
                }
            }
        }
        static public void PrintSortedList()
        {
            Console.WriteLine($"this many{accesoriesList.Count}");
            Console.WriteLine($"this many{boardGamesList.Count}");
            Console.WriteLine($"this many{booksList.Count}");
            Console.WriteLine($"this many{merchandiseList.Count}");
            Console.WriteLine($"this many{moviesList.Count}");
            Console.WriteLine($"this many{videoGamesList.Count}");
            foreach (Accessories accessories in accesoriesList)
            {
                Console.WriteLine(accessories.ToString());
            }
            foreach(BoardGames boardGames in boardGamesList)
            {
                Console.WriteLine(boardGames.ToString());
            }
            foreach(Book book in booksList)
            {
                Console.WriteLine(book.ToString());
            }
            foreach(Merchandise merchandise in merchandiseList)
            {
                Console.WriteLine(merchandise.ToString());
            }
            foreach(Movies movies in moviesList)
            {
                Console.WriteLine(movies.ToString());
            }
            foreach (VideoGames videoGames in videoGamesList) 
            {
                Console.WriteLine(videoGames.ToString());
            }
            Console.WriteLine("TITLE");
        }
    }
}
