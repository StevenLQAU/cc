using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Email.Exceptions
{
    public class EmailSendException: Exception
    {
        public EmailSendException(string message) : base(message) { }
    }
}
