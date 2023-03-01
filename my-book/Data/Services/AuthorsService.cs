using System;
using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Data.Services
{
    public class AuthorsService
    {
        AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author(){
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}