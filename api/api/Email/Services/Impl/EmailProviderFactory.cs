using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Services;

namespace api.Email.Impl.Services
{
    public class EmailProviderFactory : IEmailProviderFactory
    {
        public EmailProviders CurrentEmailProvider { get; set; }

        public EmailProviderFactory()
        {
            CurrentEmailProvider = EmailProviders.SendGrid;
        }

        public void SwitchToBackup()
        {
            if (CurrentEmailProvider == EmailProviders.SendGrid)
            {
                CurrentEmailProvider = EmailProviders.Mailgun;
                var switchTask = Task.Delay(60 * 1000)                   
                .ContinueWith((a) =>
                {
                    this.CurrentEmailProvider = EmailProviders.SendGrid;
                });
            }        
        }

        public ISender GetEmailService()
        {
            switch (CurrentEmailProvider)
            {
                case EmailProviders.SendGrid:
                    return new SendGrid();
                case EmailProviders.Mailgun:
                    return new Mailgun();
                default:
                    throw new Exception("Wrong provider");
            }
        }
    }

    
}
