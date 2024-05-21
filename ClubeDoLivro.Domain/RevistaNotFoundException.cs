using System;
using System.Runtime.Serialization;

namespace ClubeDoLivro.Domain
{
    [Serializable]
    public class RevistaNotFoundException : Exception
    {
        public RevistaNotFoundException()
        {
        }

        public RevistaNotFoundException(string message) : base(message)
        {
        }

        public RevistaNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RevistaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}