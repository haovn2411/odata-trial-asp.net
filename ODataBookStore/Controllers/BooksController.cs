using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBookStore.Entity;
using ODataBookStore.Model;

namespace ODataBookStore.Controllers
{
    [Route("odata/Books")]
    [ApiController]
    public class BooksController : ODataController
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }
        //skip = pageSize* (pageNumber - 1) = 10 * (3 - 1) = 20
        //top = pageSize = 10
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_context.Books.FirstOrDefault(c => c.Id == key));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            _context.Books.Add(book);
            _context.SaveChanges();
            return Created();
        }
        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == key);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{key}")]
        public IActionResult Update(int key, [FromBody] UpdateBookModel book)
        {
            Book bookExisted = _context.Books.FirstOrDefault(x => x.Id == key);
            if (book == null)
            {
                return NotFound();
            }
            bookExisted.Author = book.Author;
            bookExisted.ISBN = book.ISBN;
            bookExisted.Price = book.Price;
            bookExisted.Location = book.Location;
            bookExisted.PressId = book.PressId;
            bookExisted.Title = book.Title;

            _context.Books.Update(bookExisted);
            _context.SaveChanges();
            return Ok();
        }
    }
}
