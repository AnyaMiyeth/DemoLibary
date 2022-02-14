using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Autor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthyday { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
