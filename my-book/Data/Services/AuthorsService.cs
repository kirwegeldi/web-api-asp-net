using System;
using System.Collections.Generic;
using System.Linq;
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
        public AuthorWithBooksVM GetAuthorById(int AuthorId)
        {
            var _author = _context.Authors.Where(n => n.Id == AuthorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}