using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_book.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {

            _context = context;

        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthoreIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                //_book.Book_Authors.Add(_context.Books_Authors.FirstOrDefault(n => n.Id == id));
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }
        public List<BookWithAuthorsVM> GetAllBooks()
        {
            var _allBooks = _context.Books.Select(n => new BookWithAuthorsVM()
            {
                Title = n.Title,
                Description = n.Description,
                IsRead = n.IsRead,
                DateRead = n.IsRead ? n.DateRead.Value : null,
                Rate = n.IsRead ? n.Rate.Value : null,
                Genre = n.Genre,
                CoverUrl = n.CoverUrl,
                PublisherName = n.Publisher.Name,
                AuthorNames = n.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).ToList();
            return _allBooks;
        }
        public Dictionary<int,string> GetAllBookIds() => _context.Books.ToDictionary(n => n.Id,n => n.Title);
        public BookWithAuthorsVM GetBookById(int bookId) 
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(n => new BookWithAuthorsVM()
            {
                Title = n.Title,
                Description = n.Description,
                IsRead = n.IsRead,
                DateRead = n.IsRead ? n.DateRead.Value : null,
                Rate = n.IsRead ? n.Rate.Value : null,
                Genre = n.Genre,
                CoverUrl = n.CoverUrl,
                PublisherName = n.Publisher.Name,
                AuthorNames = n.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }
        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
