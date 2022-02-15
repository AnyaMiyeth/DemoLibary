using DTOs.Books;
using Excepciones.Editorials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BookService
    {
        private readonly BibliotecaContext _context;
        public BookService(BibliotecaContext context)
        {
            _context = context;
        }
        public SaveBookResponse Save(BookDTO book)
        {
            try
            {

                if (EditorialIsValid(book.IdEditorial))
                {
                    if (AutorlIsValid(book.IdAutor))
                    {

                        if (NumberBookAllowedIsValid(book.IdEditorial))
                        {
                            _context.Books.Add(book);

                            _context.SaveChanges();
                            return new SaveBookResponse(book);
                        }

                        throw new EditorialNotFoundException($" No es posible registrar el libro, se alcanzó el máximo permitido");

                    }

                    throw new EditorialNotFoundException($"El autor no está registrado");

                }
                throw new EditorialNotFoundException("La editorial no está registrada"); 

            }
            catch (Exception e)
            {
                return new SaveBookResponse($"Error de la Aplicacion: {e.Message}");
            }

        }

        private bool NumberBookAllowedIsValid(int id)
        {
            var NumberOfBooksSave = _context.Books.Where(l => l.IdEditorial == id).Count();
            var editorial = _context.Editorials.Where(e => e.Id == id).FirstOrDefault();
            if (NumberOfBooksSave >= editorial.MaximumNumberOfBook)
            {
                return false;
            }
            return true;
        }

        private bool EditorialIsValid(int id)
        {
            var editorial = _context.Editorials.Where(e => e.Id == id).FirstOrDefault();
            if (editorial == null)
            {
                return false;
            }
            return true;

        }

        private bool AutorlIsValid(int id)
        {
            var autor = _context.Editorials.Where(e => e.Id == id).FirstOrDefault();
            if (autor == null)
            {
                return false;
            }
            return true;

        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _context.Books.AsEnumerable().Select(b=> new BookDTO() 
            { 
            
            
            });
        }
    }
}
