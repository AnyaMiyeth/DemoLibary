using DTOs.Books;
using Entidades;
using Excepciones.Autor;
using Excepciones.Book;
using Excepciones.Editorials;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class BookService : IBookService
    {
        private readonly BibliotecaContext _context;
        public BookService(BibliotecaContext context)
        {
            _context = context;
        }


        public async Task<SaveBookResponse> SaveAsync(BookDTO bookDTO)
        {

            if (!EditorialExist(bookDTO.IdEditorial))
            {
                throw new EditorialNotFoundException("La editorial no está registrada");
            }

            if (!AutorExist(bookDTO.IdAutor))
            {
                throw new AutorNotFoundException($"El autor no está registrado");
            }

            if (!CountBookInEditorialAllowedIsValid(bookDTO.IdEditorial))
            {
                throw new BookLimitException($" No es posible registrar el libro, se alcanzó el máximo permitido");
            }

            var _book = MapBook(bookDTO);
            _context.Books.Add(_book);
            await _context.SaveChangesAsync();
            return new SaveBookResponse(bookDTO);


        }
        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            return await _context.Books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Year = b.Year,
                Genres = b.Genres,
                NumberOfPages = b.NumberOfPages,
                IdEditorial = b.IdEditorial,
                IdAutor = b.IdAutor,

            }).ToListAsync();
        }
        private static Book MapBook(BookDTO book)
        {
            return new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                Genres = book.Genres,
                NumberOfPages = book.NumberOfPages,
                IdEditorial = book.IdEditorial,
                IdAutor = book.IdAutor,

            };
        }

        private bool CountBookInEditorialAllowedIsValid(int id)
        {
            var numberOfBooksSave = _context.Books.Count(l => l.IdEditorial == id);
            var editorial = _context.Editorials.FirstOrDefault(e => e.Id == id);
            if (editorial.MaximumNumberOfBook != -1 && numberOfBooksSave >= editorial.MaximumNumberOfBook)
            {
                return false;
            }
            return true;
        }

        private bool EditorialExist(int id)
        {
            return _context.Editorials.Any(e => e.Id == id);
        }

        private bool AutorExist(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }


    }
}
