using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Autores
{
    public class GetAutorResponse : IErrorResponse
    {
        public IEnumerable<AutorDTO> Autores { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public GetAutorResponse(IEnumerable<AutorDTO> autores)
        {
            Autores = autores;
            Success = true;
        }

        public GetAutorResponse(string message)
        {
            Message = message;
            Success = false;
        }
    }
}
