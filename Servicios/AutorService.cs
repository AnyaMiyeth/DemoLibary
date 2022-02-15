using DTOs.Autores;
using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class AutorService : IAutorService
    {
        private BibliotecaContext _context;
        public AutorService(BibliotecaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AutorDTO>> GetAllAsync()
        {
            var autores = await _context.Autores.Select(a => new AutorDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Birthday = a.Birthday,
                CityOfOrigin = a.CityOfOrigin,
                Email = a.Email,
            }).ToListAsync();

            return autores;


        }
        public async Task<AutorDTO> SaveAsync(AutorDTO autorDTO)
        {

            var autor = MapperAutor(autorDTO);
            _context.Add(autor);
            await _context.SaveChangesAsync();
            autorDTO.Id = autor.Id;
            return autorDTO;

        }
        private static Autor MapperAutor(AutorDTO autorDTO)
        {
            return new Autor()
            {

                Id = autorDTO.Id,
                Name = autorDTO.Name,
                Birthday = autorDTO.Birthday,
                CityOfOrigin = autorDTO.CityOfOrigin,
                Email = autorDTO.Email,
            };
        }
    }

}
