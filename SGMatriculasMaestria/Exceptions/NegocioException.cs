﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Exceptions
{
    public class NegocioException : Exception
    {
        public NegocioException(string message) : base(message)
        {
        }
    }
}
