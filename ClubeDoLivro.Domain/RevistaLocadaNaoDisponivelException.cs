using System;
using System.Runtime.Serialization;

namespace ClubeDoLivro.Domain
{
    [Serializable]
    internal class RevistaLocadaNaoDisponivelException : Exception
    {
        public RevistaLocadaNaoDisponivelException() : this("A revista encontra-se locada.")
        {
        }

        public RevistaLocadaNaoDisponivelException(string message) : base(message)
        {
        }

        public RevistaLocadaNaoDisponivelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RevistaLocadaNaoDisponivelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}