using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genres { get; set; }
        public int NumberOfPages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }

        public Autor Autor { get; set; }
        public Editorial Editorial { get; set; }

    }
}
