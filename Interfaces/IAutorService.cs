using DTOs.Autores;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAutorService
    {
        Task<GetAutorResponse> GetAllAsync();
        Task<SaveAutorResponse> SaveAsync(AutorDTO autorDTO);
    }
}