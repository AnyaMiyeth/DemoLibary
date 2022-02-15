using DTOs.Books;
using Entidades;
using Excepciones.Autor;
using Excepciones.Book;
using Excepciones.Editorials;
using Interfaces;
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


        public async Task<BookDTO> SaveAsync(BookDTO bookDTO)
        {
            if (!EditorialExist(bookDTO.IdEditorial))
            {
                throw new EditorialNotFoundException("La editorial no está registrada");
            }
            if (!AutorExist(bookDTO.IdAutor))
            {
                throw new AutorNotFoundException($"El autor no está registrado");
            }
            if (!NumberBookAllowedInEditorial(bookDTO.IdEditorial))
            {
                throw new BookLimitException($" No es posible registrar el libro, se alcanzó el máximo permitido");
            }
            var book = MapBook(bookDTO);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            bookDTO.Id=book.Id;
            return bookDTO;
        }
        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _context.Books.Include(t=>t.Autor).Select(b => new BookDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Year = b.Year,
                Genres = b.Genres,
                NumberOfPages = b.NumberOfPages,
                IdEditorial = b.EditorialId,
                IdAutor = b.AutorId,
                Autor = b.Autor.Name,
                Editorial=b.Editorial.Name

            }).ToListAsync();

            return books;
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
                EditorialId = book.IdEditorial,
                AutorId = book.IdAutor,

            };
        }

        private bool NumberBookAllowedInEditorial(int id)
        {
            var numberOfBooksSave = _context.Books.Count(l => l.EditorialId == id);
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
