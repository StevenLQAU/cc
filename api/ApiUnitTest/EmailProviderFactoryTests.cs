using System;
using System.Collections.Generic;
using System.Text;
using api.Email.Impl.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUnitTest
{
    [TestClass]
    public class EmailProviderFactoryTests
    {
        [TestMethod]
        public void EmailProviderFactory_CanGetService()
        {
            EmailProviderFactory ef = new EmailProviderFactory();

            var s = ef.GetEmailService();
            Assert.AreEqual(s.GetType(), typeof(SendGrid));
        }

        [TestMethod]
        public void EmailProviderFactory_CanSwitch()
        {
            EmailProviderFactory ef = new EmailProviderFactory();

            var s = ef.GetEmailService();
            ef.SwitchToBackup();
            s = ef.GetEmailService();
            Assert.AreEqual(s.GetType(), typeof(Mailgun));
        }
    }
}
