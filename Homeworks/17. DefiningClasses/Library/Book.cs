using System;
using System.Linq;



namespace Library
{
    public class Book
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        private string publishedYear;

        public string PublishedYear
        {
            get { return publishedYear; }
            set { publishedYear = value; }
        }
        private string ISBN;

        public string ISBN1
        {
            get { return ISBN; }
            set { ISBN = value; }
        }

        public Book(string title, string author, string publisher, string publishedYear, string ISBN)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            PublishedYear = publishedYear;
            ISBN1 = ISBN;

        }

        public void ViewBook()
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("Year: {0}", PublishedYear);
            Console.WriteLine("Publisher: {0}", Publisher);
        }

    }
}
