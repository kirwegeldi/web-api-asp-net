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
        public List<BookWithAuthorsVM> Books{ get; set; }
    }
}