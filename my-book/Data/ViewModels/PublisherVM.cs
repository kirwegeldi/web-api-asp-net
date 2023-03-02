using System;
using System.Collections.Generic;
using my_book.Data.Models;

namespace my_book.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }

    }
    public class PublisherWithBooksVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BooksAndAuthors{ get; set; }
    }
    public class BookAuthorVM
    {
        public string BookTitle { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}