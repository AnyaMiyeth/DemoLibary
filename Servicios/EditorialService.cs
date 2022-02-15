using DTOs.Editorals;
using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class EditorialService : IEditorialService
    {
        private readonly BibliotecaContext _context;
        public EditorialService(BibliotecaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EditorialDTO>> GetAll()
        {

            return await _context.Editorials.Select(e => new EditorialDTO()
            {
                Id = e.Id,
                Name = e.Name,
                CorrespondenceAddress =
                e.CorrespondenceAddress,
                Email = e.Email,
                Telephon = e.Telephon,
                MaximumNumberOfBook = e.MaximumNumberOfBook
            }).ToListAsync();


        }
        public async Task<EditorialDTO> Save(EditorialDTO editorialDTO)
        {
            var editorial = MapperEditorial(editorialDTO);
            _context.Editorials.Add(editorial);
            await _context.SaveChangesAsync();
            editorialDTO.Id = editorial.Id;
            return editorialDTO;
        }
        private static Editorial MapperEditorial(EditorialDTO editorialRequest)
        {
            return new Editorial
            {
                Name = editorialRequest.Name,
                CorrespondenceAddress = editorialRequest.CorrespondenceAddress,
                Telephon = editorialRequest.Telephon,
                Email = editorialRequest.Email,
                MaximumNumberOfBook = editorialRequest.MaximumNumberOfBook,
            };
        }
    }
}
