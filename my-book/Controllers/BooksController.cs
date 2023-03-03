using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book) 
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }
        [HttpGet("get-all-book-Ids")]
        public IActionResult GetAllBookIds()
        {
            var _books = _booksService.GetAllBookIds();
            return Ok(_books);
        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id,book);
            return Ok(updatedBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
