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

    }
}