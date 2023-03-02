using System;
using my_book.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorsService _authorServices;
        public AuthorsController(AuthorsService authorsServices)
        {
            _authorServices = authorsServices;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
            _authorServices.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-by-Id/{Id}")]
        public IActionResult GetAuthorById(int Id)
        {
            var _author = _authorServices.GetAuthorById(Id);
            return Ok(_author);
        }


    }
}