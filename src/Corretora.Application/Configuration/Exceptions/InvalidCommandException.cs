using System;
using System.Collections.Generic;

namespace Corretora.Application.Configuration.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
