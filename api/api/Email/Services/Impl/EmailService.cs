using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Exceptions;
using api.Email.Services;

namespace api.Email.Impl.Services
{
    public class EmailService: IEmailService
    {
        private readonly IEmailProviderFactory _emailProviderFactory;

        public EmailService(IEmailProviderFactory emailProviderFactory)
        {
            _emailProviderFactory = emailProviderFactory;
        }

        public string SendEmail(SendEmailRequest sendEmailRequest)
        {
            var provider = _emailProviderFactory.GetEmailService();
            try
            {
                return provider.Send(sendEmailRequest);
            }
            catch (EmailSendException)
            {
                _emailProviderFactory.SwitchToBackup();
                provider = _emailProviderFactory.GetEmailService();
                return provider.Send(sendEmailRequest);
            }
            catch (Exception)
            {
                // TODO: log here
                throw;
            }
        }
    }
}
