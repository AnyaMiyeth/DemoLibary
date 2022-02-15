using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.Autor
{
    [Serializable]
    public class AutorNotFoundException:Exception
    {
        public AutorNotFoundException(string message)
             : base(message) { }
    }
}
