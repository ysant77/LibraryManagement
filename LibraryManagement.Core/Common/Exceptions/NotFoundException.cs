﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Core.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" with Id ({key}) was not found.")
        {
        }
    }
}
