﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.CustomExceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() { }

        public UnauthorizedException(string message)
            : base(message) { }

        public UnauthorizedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
