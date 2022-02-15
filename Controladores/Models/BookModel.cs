using DTOs.Books;
using System.ComponentModel.DataAnnotations;

namespace Controladores.Models
{
    public class BookInputModel
    {
        [Required(ErrorMessage = "Titulo del Libro Requerido")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Año del Libro Requerido")]
        public string Year { get; set; }
        public string Genres { get; set; }
        public int NumberOfPages { get; set; }
        [Required(ErrorMessage = "Editorial Requerida")]
        public int IdEditortial { get; set; }
        [Required(ErrorMessage = "Autor Requerido")]
        public int IdAutor { get; set; }
    }

    public class BookViewModel : BookInputModel
    {
        public int Id { get; set; }
        public BookViewModel(BookDTO book)
        {
            Id = book.Id;
            Title = book.Title;
            Year = book.Year;
            Genres = book.Genres;
            NumberOfPages = book.NumberOfPages;
            IdEditortial = book.IdEditorial;
            IdAutor = book.IdAutor;

        }
    }
}
