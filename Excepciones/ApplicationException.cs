using System;

namespace Excepciones
{
    [Serializable]
    public class ApplicationException : Exception
    {
        public ApplicationException() { }

        public ApplicationException(string message)
            : base(message) { }


    }
}
