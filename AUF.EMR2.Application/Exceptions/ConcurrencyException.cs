﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Exceptions
{
    public class ConcurrencyException : ApplicationException
    {
        public ConcurrencyException(string message) : base(message) { }
        public ConcurrencyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
