using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.Email.Controllers.Models
{
    public class SendEmailResult
    {
        public string Result { get; set; }

        public SendEmailResult(string result)
        {
            Result = result;
        }
    }
}
