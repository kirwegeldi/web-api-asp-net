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
            var _publisher = new Publisher()
            {
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
                BooksAndAuthors = n.Books.Select(n=> new BookAuthorVM(){
                BookTitle = n.Title,
                AuthorsName = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisher;
        }
        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}