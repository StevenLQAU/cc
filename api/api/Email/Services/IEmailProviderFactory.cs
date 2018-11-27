using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Email.Services
{
    public interface IEmailProviderFactory
    {
        EmailProviders CurrentEmailProvider { get; set; }
        void SwitchToBackup();
        ISender GetEmailService();
    }
}
