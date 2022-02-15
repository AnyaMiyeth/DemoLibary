using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.Book
{
    [Serializable]
    public class BookLimitException: ApplicationException
    {
        public BookLimitException(string message)
            : base(message) { }
    }
}
