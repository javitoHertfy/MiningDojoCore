using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.CustomExceptions
{
    public class TryingToStealException : Exception
    {
        public TryingToStealException() { }

        public TryingToStealException(string message)
            : base(message) { }

        public TryingToStealException(string message, Exception inner)
            : base(message, inner) { }
    }
}
