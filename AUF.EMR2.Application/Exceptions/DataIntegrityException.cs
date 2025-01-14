﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Exceptions
{
    public class DataIntegrityException : ApplicationException
    {
        public DataIntegrityException(string message) : base(message) { } 
        public DataIntegrityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
