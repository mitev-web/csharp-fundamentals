using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            //We are given a library of books. Define classes for the library and the books. 
            //The library should have name and a list of books. 
            //The books have title, author, publisher, year of publishing and ISBN. Keep the books in List<Book> 
            //(first find how to use the class System.Collections.Generic.List<T>).
            //Implement methods for adding, searching by title and author, displaying and deleting books.\
            //Write a test class that creates a library, adds few books to it and displays them.
            //Find all books by Nakov, delete them and print again the library.
            Book book1 = new Book("Encarta Encyclopedia", "Tom Jones", "Izdanie Trud", "1989", "sfrsdfr9342343");
            Book book2 = new Book("Raznovidnosti na ruskiq ribolov", "James Brown", "Prosveta", "1983", "sfrsf2342343");
            Book book3 = new Book("Introduction Programming with C#", "Svetlin Nakov", "Prosveta", "2011", "sfrsf2342343");
            Book book4 = new Book("Introduction Programming with Java", "Svetlin Nakov", "Prosveta", "1985", "sfrsf2342343");

            List<Book> books = new List<Book> { book1, book2, book3, book4 };

            Library library = new Library(books);
            library.Name = "My cool new library";
            //view books in newly created library
            library.ViewAllBooks();

            List<Book> NakovBooks = library.GetBooksByAuthor("Svetlin Nakov");

            //see how many Nakov books are there now
            Console.WriteLine();
            Console.WriteLine("There are {0} Nakov's books in the library", NakovBooks.Count);
            Console.WriteLine();
            foreach (Book NakovBook in NakovBooks)
            {
                library.DeleteBook(NakovBook);
            }
            //view library after deleting Nakov's Books
            library.ViewAllBooks();
            //see how many Nakov books are there now
            NakovBooks = library.GetBooksByAuthor("Svetlin Nakov");
            Console.WriteLine("Now there are {0} Nakov's books in the library", NakovBooks.Count);
        }
    }
}