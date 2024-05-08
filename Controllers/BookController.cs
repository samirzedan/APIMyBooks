using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMyBooks.Data;
using APIMyBooks.Models;
using APIMyBooks.ViewModels;

namespace APIMyBooks.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet("books")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            var books = context
                .Books
                .AsNoTracking()
                .ToList();

            return Ok(books);
        }

        [HttpGet("books/{id}")]
        public IActionResult GetById([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var book = context
                .Books
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return book == null
                ? NotFound()
                : Ok(book);
        }

        [HttpPost("books")]
        public IActionResult Post([FromServices] AppDbContext context, [FromBody] CreateBookViewModel bookModel)
        {
           if (!ModelState.IsValid)
                return BadRequest();

            var book = new Book
            (
                title: bookModel.Title,
                author: bookModel.Author,
                totalPages: bookModel.TotalPages,
                currentPage: bookModel.CurrentPage,
                startedAt: bookModel.StartedAt
            );

            try {
                context.Books.Add(book);
                context.SaveChanges();

                return Created("books/{book.Id}", book);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("books/{id}")]
        public IActionResult Put([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] UpdateBookViewModel bookModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = context.Books.FirstOrDefault(x => x.Id == id);
               
            if (book == null)
                return NotFound();

            try
            {
                book.UpdateData(
                    bookModel.Title,
                    bookModel.Author,
                    bookModel.TotalPages,
                    bookModel.StartedAt);

                context.SaveChanges();

                return Ok(book);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("books/change-page/{id}")]
        public IActionResult PatchCurrentPage([FromServices] AppDbContext context, [FromRoute] int id, [FromQuery] int currentPage)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            if (currentPage > book.TotalPages || currentPage < 0)
                return BadRequest();

            try
            {
                book.changeCurrentPage(currentPage);
                context.SaveChanges();

                return Ok(book);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("books/finalize/{id}")]
        public IActionResult PatchFinalize([FromServices] AppDbContext context, [FromRoute] int id, [FromQuery] int currentPage)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            try
            {
                book.finalizeBook();
                context.SaveChanges();

                return Ok(book);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("books/{id}")]
        public IActionResult Put([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            try
            {
                context.Books.Remove(book);
                context.SaveChanges();

                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
