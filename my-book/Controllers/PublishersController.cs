using System;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        PublisherService _publisherServices;
        public PublishersController(PublisherService publisherService)
        {
            _publisherServices = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherVM publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }
    }
}