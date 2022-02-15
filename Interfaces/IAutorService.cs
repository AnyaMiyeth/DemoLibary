using DTOs.Autores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorDTO>> GetAllAsync();
        Task<AutorDTO> SaveAsync(AutorDTO autorDTO);
    }
}