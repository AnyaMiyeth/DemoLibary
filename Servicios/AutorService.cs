using DTOs.Autores;
using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

       

        public async Task<GetAutorResponse> GetAllAsync()
        {
            try
            {
                var autores = await _context.Autores.Select(a => new AutorDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Birthday = a.Birthday,
                    CityOfOrigin = a.CityOfOrigin,
                    Email = a.Email,
                }).ToListAsync();

                return new GetAutorResponse(autores);
            }
            catch (Exception e)
            {

                return new GetAutorResponse($"Error de Aplicación al consultar: {e.Message} ");
            }


        }


        public async Task<SaveAutorResponse> SaveAsync(AutorDTO autorDTO)
        {
            try
            {
                Autor _autor = MapperAutor(autorDTO);
                _context.Add(_autor);
               await _context.SaveChangesAsync();

                return new SaveAutorResponse(autorDTO);
            }
            catch (Exception e)
            {
                return new SaveAutorResponse($"Error de Aplicaion: {e.Message} ");
            }
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
