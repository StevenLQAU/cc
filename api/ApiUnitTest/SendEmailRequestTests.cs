using System.Collections.Generic;
using api.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUnitTest
{
    [TestClass]
    public class SendEmailRequestTests
    {
        [TestMethod]
        public void SendEmailRequest_ShouldBeValid()
        {
            SendEmailRequest req = new SendEmailRequest();
            req.Subject = "subject";
            req.Recipients = new List<string>(){"1"};

            Assert.IsTrue(req.IsValid());
        }

        [TestMethod]
        public void SendEmailRequest_ShouldNotBeValid()
        {
            SendEmailRequest req = new SendEmailRequest();
            req.Subject = null;
            req.Recipients = new List<string>() { "1" };

            Assert.IsFalse(req.IsValid());

            req.Subject = "";
            req.Recipients = new List<string>() { "1" };

            Assert.IsFalse(req.IsValid());

            req.Subject = "subject";
            req.Recipients = new List<string>();

            Assert.IsFalse(req.IsValid());
        }

    }
}
