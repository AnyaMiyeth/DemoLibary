using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return new GetAutorResponse(_context.Autores.AsEnumerable());
            }
            catch (Exception e)
            {

                return new GetAutorResponse($"Error de Aplicaion al consultar: {e.Message} ");
            }


        }


        public SaveAutorResponse Save(Autor autor)
        {
            try
            {
                _context.Add(autor);
                _context.SaveChanges();

                return new SaveAutorResponse(autor);
            }
            catch (Exception e)
            {

                return new SaveAutorResponse($"Error de Aplicaion: {e.Message} ");
            }
        }
    }

    
}
