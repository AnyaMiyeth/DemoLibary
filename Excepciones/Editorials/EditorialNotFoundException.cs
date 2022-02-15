using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.Editorials
{
    [Serializable]
    public class EditorialNotFoundException:Exception
    {
       

        public EditorialNotFoundException() { }

        public EditorialNotFoundException(string message)
            : base(message) { }

      
    }
}
