using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Exceptions
{
    public class DuplicateEntriesException : Exception
    {
        public DuplicateEntriesException(string name, object key)
            : base($"\"{name}\" with ({key}) already exists.")
        {
        }
    }
}
