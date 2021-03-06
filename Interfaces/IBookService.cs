using DTOs.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<BookDTO> SaveAsync(BookDTO bookDTO);
    }
}