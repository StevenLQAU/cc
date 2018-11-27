using System;
using System.Collections.Generic;
using System.Text;
using api.Email;
using api.Email.Exceptions;
using api.Email.Impl.Services;
using api.Email.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApiUnitTest
{
    [TestClass]
    public class EmailServiceTests
    {
        private Mock<IEmailProviderFactory> _epfMock = new Mock<IEmailProviderFactory>();
        private Mock<ISender> _senderMock = new Mock<ISender>();

        private IEmailService _emailService;


        [TestInitialize]
        public void Init()
        {
            

            _emailService = new EmailService(_epfMock.Object);
        }

        [TestMethod]
        public void EmailService_CanSend()
        {
            _epfMock.Setup(x => x.GetEmailService()).Returns(_senderMock.Object);
            _senderMock.Setup(x => x.Send(It.IsAny<SendEmailRequest>())).Returns("abc");
            Assert.AreEqual(_emailService.SendEmail(new SendEmailRequest()), "abc");
        }

        [TestMethod]
        public void EmailService_CanFailOver()
        {
            _epfMock.Setup(x => x.GetEmailService()).Returns(_senderMock.Object);
            _epfMock.Setup(x => x.SwitchToBackup()).Callback(() =>
            {
                _senderMock.Setup(x => x.Send(It.IsAny<SendEmailRequest>())).Returns("abc");
            });
            _senderMock.Setup(x => x.Send(It.IsAny<SendEmailRequest>())).Throws(new EmailSendException("aaa"));
            Assert.AreEqual(_emailService.SendEmail(new SendEmailRequest()), "abc");
        }
    }
}
