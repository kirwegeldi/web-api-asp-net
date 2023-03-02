using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Data.Services
{
    public class PublisherService
    {
        AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher(){
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksVM GetPublisherById(int publishedId)
        {
            var _publisher = _context.Publishers.Where(n => n.Id == publishedId).Select(n => new PublisherWithBooksVM()
            {
                Name = n.Name,
                Books = n.Books.Select(book => new BookWithAuthorsVM()
                {
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead.Value : null,
                    Rate = book.IsRead ? book.Rate.Value : null,
                    Genre = book.Genre,
                    CoverUrl = book.CoverUrl,
                    PublisherName = book.Publisher.Name,
                    AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
                    
                }).ToList()
            }).FirstOrDefault();
            return _publisher;
        }
    }
}