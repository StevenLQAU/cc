using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Email.Exceptions
{
    public class RequestNotValidException: Exception
    {
        public RequestNotValidException(string message) : base(message) { }
    }
}
