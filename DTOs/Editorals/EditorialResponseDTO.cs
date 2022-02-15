
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Editorals
{
    public class EditorialResponseDTO
    {
        public EditorialResponseDTO(EditorialDTO editorial)
        {
            Editorial = editorial;
            Success = true;
        }

        public EditorialResponseDTO(string message)
        {
            Message = message;
            Success = false;
        }

        public EditorialDTO Editorial { get; }
        public string Message { get; }
        public bool Success { get; set; }
    }
}
