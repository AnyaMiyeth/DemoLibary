using DTOs.Editorals;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class EditorialService
    {
        private readonly BibliotecaContext _context;
        public EditorialService(BibliotecaContext context)
        {
            _context = context;
        }

        public GetEditorialDTO GetAll()
        {
            try
            {
                return new GetEditorialDTO(_context.Editorials.AsEnumerable().Select(e => new EditorialDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    CorrespondenceAddress =
                    e.CorrespondenceAddress,
                    Email = e.Email,
                    Telephon = e.Telephon,
                    MaximumNumberOfBook = e.MaximumNumberOfBook
                }));
            }
            catch (Exception e)
            {
                return new GetEditorialDTO($"Error de la Aplicacion al Consultar: {e.Message}");
            }

        }
        public EditorialResponseDTO Save(EditorialDTO editorialDTO)
        {
            try
            {
                Editorial editorial = MapEditorial(editorialDTO);
                _context.Editorials.Add(editorial);
                _context.SaveChanges();

                return new EditorialResponseDTO(editorialDTO);
            }
            catch (Exception e)
            {
                return new EditorialResponseDTO($"Error de la Aplicacion: {e.Message}");
            }

        }

        private static Editorial MapEditorial(EditorialDTO editorialRequest)
        {
            return new Editorial
            {
                Id = editorialRequest.Id,
                Name = editorialRequest.Name,
                CorrespondenceAddress = editorialRequest.CorrespondenceAddress,
                Telephon = editorialRequest.Telephon,
                Email = editorialRequest.Email,
                MaximumNumberOfBook = editorialRequest.MaximumNumberOfBook,
            };
        }
    }
}
