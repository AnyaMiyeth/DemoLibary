using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Books
{
    public class SaveBookResponse
    {
        public BookDTO Book { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public SaveBookResponse(BookDTO book)
        {
            Book = book;
            Success = false;
        }

        public SaveBookResponse(string message)
        {
            Message = message;
            Success = true;
        }
    }
}
