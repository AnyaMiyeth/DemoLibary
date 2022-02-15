using Controladores.Models;
using DTOs.Books;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<LibroController>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<BookViewModel>))]
        public async Task<IActionResult> Get()
        {
            var result = await _bookService.GetAllAsync();
            return Ok(result.Select(b => new BookViewModel(b)));
        }

        // POST api/<LibroController>
        [HttpPost]
        [Produces("application/json", Type = typeof(BookViewModel))]
        public async Task<IActionResult> Post(BookInputModel bookInput)
        {
            BookDTO _book = MapearLibro(bookInput);
            var response = await _bookService.SaveAsync(_book);
            return Ok(new BookViewModel(response));
        }

        private static BookDTO MapearLibro(BookInputModel libroInput)
        {
            return new BookDTO
            {
                Title = libroInput.Title,
                Year = libroInput.Year,
                NumberOfPages = libroInput.NumberOfPages,
                Genres = libroInput.Genres,
                IdEditorial = libroInput.EditorialId,
                IdAutor = libroInput.AutorId,
            };
        }
    }
}
