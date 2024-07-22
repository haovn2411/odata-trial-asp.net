using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository.Entity;
using ODataBookStore.Model;
using Repository;

namespace ODataBookStore.Controllers
{
    [Route("odata/Books")]
    [ApiController]
    public class BooksController : ODataController
    {
        private readonly UnitOfWork _unitOfWork;

        public BooksController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.BookRepository.Get().ToList());
        }
        //skip = pageSize* (pageNumber - 1) = 10 * (3 - 1) = 20
        //top = pageSize = 10
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_unitOfWork.BookRepository.GetByID(key));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            _unitOfWork.BookRepository.Insert(book);
            _unitOfWork.Save();
            return Created();
        }
        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            Book book = _unitOfWork.BookRepository.GetByID(key);
            if (book == null)
            {
                return NotFound();
            }

            _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.Save();
            return Ok();
        }
        [HttpPut("{key}")]
        public IActionResult Update(int key, [FromBody] UpdateBookModel book)
        {
            Book bookExisted = _unitOfWork.BookRepository.GetByID(key);
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

            _unitOfWork.BookRepository.Update(bookExisted);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
