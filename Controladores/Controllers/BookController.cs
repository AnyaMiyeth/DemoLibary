using Controladores.Models;
using DTOs.Books;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService _bookService;
        public BookController(BibliotecaContext context)
        {
            _bookService = new BookService(context);
        }
        // GET: api/<LibroController>
        [HttpGet]
        public IEnumerable<BookViewModel> Get()
        {
            return _bookService.GetAll().Select(b=> new BookViewModel(b));
        }



        // POST api/<LibroController>
        [HttpPost]
        public ActionResult<BookViewModel> Post(BookInputModel bookInput)
        {
            BookDTO _book = MapearLibro(bookInput);

            var response = _bookService.Save(_book);
            if (response.Success == true)
            {
                return BadRequest(response.Message);
            }
            return Ok(new BookViewModel(response.Book));
        }

        private static BookDTO MapearLibro(BookInputModel libroInput)
        {
            return new BookDTO
            {
                Title = libroInput.Title,
                Year = libroInput.Year,
                NumberOfPages = libroInput.NumberOfPages,
                Genres = libroInput.Genres,
                IdEditorial = libroInput.IdEditortial,
                IdAutor = libroInput.IdAutor,

            };
        }
    }
}
