using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Library
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Book> books;

        internal List<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
            }
        }

        public Library(List<Book> books)
        {
            Books = books;
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void ViewBook(Book book)
        {
            Console.WriteLine("Title: {0}", book.Title);
            Console.WriteLine("Author: {0}", book.Author);
            Console.WriteLine("Year: {0}", book.PublishedYear);
            Console.WriteLine("Publisher: {0}", book.Publisher);
        }

        public void ViewAllBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Title: {0}", book.Title);
                Console.WriteLine("Author: {0}", book.Author);
                Console.WriteLine("Year: {0}", book.PublishedYear);
                Console.WriteLine("Publisher: {0}", book.Publisher);
                Console.WriteLine("------------------------");
            }
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Author == author)
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}