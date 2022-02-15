using DTOs.Autores;
using Entidades;
using System;
using System.Linq;

namespace Servicios
{
    public class AutorService
    {
        private BibliotecaContext _context;
        public AutorService(BibliotecaContext context)
        {
            _context = context;
        }

        public GetAutorResponse GetAll()
        {
            try
            {
                return new GetAutorResponse(_context.Autores.AsEnumerable().Select(a => new AutorDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Birthday = a.Birthday,
                    CityOfOrigin = a.CityOfOrigin,
                    Email = a.Email,

                }));
            }
            catch (Exception e)
            {

                return new GetAutorResponse($"Error de Aplicaion al consultar: {e.Message} ");
            }


        }


        public SaveAutorResponse Save(AutorDTO autorDTO)
        {
            try
            {
                var _autor = new Autor()
                {

                    Id = autorDTO.Id,
                    Name = autorDTO.Name,
                    Birthday = autorDTO.Birthday,
                    CityOfOrigin = autorDTO.CityOfOrigin,
                    Email = autorDTO.Email,
                };
                _context.Add(_autor);
                _context.SaveChanges();

                return new SaveAutorResponse(autorDTO);
            }
            catch (Exception e)
            {

                return new SaveAutorResponse($"Error de Aplicaion: {e.Message} ");
            }
        }
    }


}
