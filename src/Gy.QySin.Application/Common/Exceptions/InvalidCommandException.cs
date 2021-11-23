using System;

namespace Gy.QySin.Application.Common.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
            : base("Comando no válido. Revise que el nombre de la Entidad y del comando sean correctos.")
        {
        }
    }
}