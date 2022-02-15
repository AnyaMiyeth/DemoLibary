using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Autor
    {
        private ICollection<Book> books;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }

        public ICollection<Book> Books { get => books; set => books = value; }

    }
}
