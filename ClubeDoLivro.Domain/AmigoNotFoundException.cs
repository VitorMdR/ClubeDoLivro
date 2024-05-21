using System;
using System.Runtime.Serialization;

namespace ClubeDoLivro.Domain
{
    [Serializable]
    public class AmigoNotFoundException : Exception
    {
        public AmigoNotFoundException()
        {
        }

        public AmigoNotFoundException(string message) : base(message)
        {
        }

        public AmigoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AmigoNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}