
using System.Collections.Generic;
using System.Linq;
using api.Email.Exceptions;

namespace api.Email
{
    public class SendEmailRequest
    {
        public IEnumerable<string> Recipients { get; set; }
        public IEnumerable<string> BBs { get; set; }
        public IEnumerable<string> CCs { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public bool IsValid()
        {
            if (!Recipients.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(Subject))
            {
                return false;
            }

            return true;
        }
    }
}
