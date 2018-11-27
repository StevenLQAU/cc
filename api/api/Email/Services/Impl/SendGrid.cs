using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Exceptions;
using api.Email.Services;

namespace api.Email.Impl.Services
{
    public class SendGrid: ISender
    {
        public string Send(SendEmailRequest sendEmailRequest)
        {
            if (sendEmailRequest.Subject == "failed")
            {
                throw new EmailSendException("Email send by SendGrid failed.");
            }
            return "Email send by SendGrid successfully.";
        }
    }
}