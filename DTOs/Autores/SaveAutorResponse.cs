using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DTOs.Autores
{
    public record SaveAutorResponse
    {
        public Autor Autor { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public SaveAutorResponse(Autor autor)
        {
            Autor = autor;
            Success = true;
        }

        public SaveAutorResponse(string message)
        {
            Message = message;
            Success = false;
        }
    }
}
