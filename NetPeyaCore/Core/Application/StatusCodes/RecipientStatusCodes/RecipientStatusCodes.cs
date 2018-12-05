using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.StatusCodes.Recipients
{
    public class RecipientStatusCodes : SharedStatusCodes
    {
        public const int MissingEmailandPhone = 1001;
        public const int UserNotFound = 1002;
    }
}
