using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Impl.Services;
using api.Email.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api
{
    public static class ConfigService
    {
        public static void Config(IServiceCollection services)
        {
            services.AddSingleton<IEmailProviderFactory, EmailProviderFactory>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
