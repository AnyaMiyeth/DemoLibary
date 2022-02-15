using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Editorals
{
    public class GetEditorialDTO
    {
        public GetEditorialDTO(IEnumerable<EditorialDTO> editoriales)
        {
            Editoriales = editoriales;
            Success = true;
        }

        public GetEditorialDTO(string message)
        {
            Message = message;
            Success = false;
        }

        public IEnumerable<EditorialDTO> Editoriales { get; }
        public string Message { get; }
        public bool Success { get; set; }
    }
}
