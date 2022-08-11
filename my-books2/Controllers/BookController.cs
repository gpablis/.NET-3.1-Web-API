using Microsoft.AspNetCore.Mvc;
using my_books2.Dtos.Book;
using my_books2.Models;
using my_books2.Services.BookService;

namespace my_books2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        // Define a private field for dependency - Interface
        private IBookService _bookService;
        // Define Constructor - Interface Implementation
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet("GetAll")]
        public IActionResult Get()
        { 
            return Ok(_bookService.GetAllBooks());
        }

        // Routing with parameters
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        { 
            return Ok(_bookService.GetBookById(id));
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto newBook)
        { 
            return Ok(_bookService.AddBook(newBook));
        }

        [HttpPut]
        public IActionResult UpdateBook(UpdateBookDto updatedBook)
        {
            return Ok(_bookService.UpdateBook(updatedBook));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            return Ok(_bookService.DeleteBook(id));
        }
    }
}
