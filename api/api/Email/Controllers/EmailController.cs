using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Email.Controllers.Models;
using api.Email.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Email.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] SendEmailRequest request)
        {
            if (request.IsValid())
            {
                var result = new SendEmailResult(_emailService.SendEmail(request));
                return Ok(result);

            }

            return BadRequest("Request is not valid");
        }
    }
}