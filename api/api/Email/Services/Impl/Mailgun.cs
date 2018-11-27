using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Exceptions;
using api.Email.Services;

namespace api.Email.Impl.Services
{
    public class Mailgun: ISender
    {
        public string Send(SendEmailRequest sendEmailRequest)
        {
            return "Email send by Mailgun successfully.";
        }
    }
}
