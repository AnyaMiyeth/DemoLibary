using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Editorals
{
    public class SaveEditorialResponse: SaveEditorialRequest
    {

        public SaveEditorialResponse(SaveEditorialRequest editorial)
        {
            Editorial = editorial;
            Success = true;
        }

        public SaveEditorialResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public SaveEditorialRequest Editorial { get; }
        public string Message { get; }
        public bool Success { get; set; }

    }
}
