using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Books
{
    public class BookDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genres { get; set; }
        public int NumberOfPages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
    }
}
