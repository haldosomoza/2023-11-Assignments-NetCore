using System.Collections.Generic;
using System.Diagnostics;

namespace BookstoreSystem
{
    internal class Bookstore
    {
        private List<Book> _Inventory;

        public Bookstore() 
        {
            _Inventory = new List<Book>();
            _Inventory.Add(new    FictionBook("Novel",     "The Great Gatsby",                      "F. Scott Fitzgerald", 15.99));
            _Inventory.Add(new NonFictionBook("History",   "Sapiens: A Brief History of Humankind", "Yuval Noah Harari",   19.99));
            _Inventory.Add(new    FictionBook("Fantasy",   "The Alchemist",                         "Paulo Coelho",        21.99));
            _Inventory.Add(new NonFictionBook("Biography", "The Diary of a Young Girl",             "Anne Frank",          12.60));
            _Inventory.Add(new    FictionBook("Dystopian", "1984",                                  "George Orwels",       16.99));
            _Inventory.Add(new NonFictionBook("Biography", "Extraordinary Women In History",        "Leah Gail",           15.52));
        }

        public List<String> DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string TextToWrite = """

                BOOKSTORE MENU
                1. Browse Books
                2. Add Books to Cart
                3. Apply Discounts
                4. View Order
                5. Exit

                """;
            Console.WriteLine(TextToWrite);
            return new List<String> { "1", "2", "3", "4", "5" };
        }

        public List<Book> GetInventory()
        {
            return _Inventory;
        }

        public Book FetchBook(int index)
        {
            return _Inventory[index-1];
        }

        public List<String> DisplayInventory()
        {
            int index = 1;
            string BookList = String.Empty;
            List<String> indexes = new List<String>();
            foreach (var Book in _Inventory)
            {
                BookList += $" {index}. {Book.GetDetails()}\n";
                indexes.Add(index.ToString());
                index++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            string TextToWrite = $"""

                AVAILABLE BOOKS
                {BookList}

                """;
            Console.Write(TextToWrite);
            return indexes;
        }

    }

}
