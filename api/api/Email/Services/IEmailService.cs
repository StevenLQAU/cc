using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Email.Services
{
    public interface IEmailService
    {
        string SendEmail(SendEmailRequest sendEmailRequest);
    }
}
