using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Domain.Exceptions
{
    class AddUserInvalidException : Exception
    {
        public AddUserInvalidException(string adUser, Exception ex) 
            : base($"AD Account \"{adUser}\" is invalid.", ex)
        {
        }
    }
}
