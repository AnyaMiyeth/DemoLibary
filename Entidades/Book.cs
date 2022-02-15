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
        public int EditorialId { get; set; }
        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Editorial Editorial { get; set; }

    }
}
