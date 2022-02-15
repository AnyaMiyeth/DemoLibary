using DTOs.Editorals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IEditorialService
    {
        Task<IEnumerable<EditorialDTO>> GetAll();
        Task<EditorialDTO> Save(EditorialDTO editorialDTO);
    }
}