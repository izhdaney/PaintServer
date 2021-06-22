using Microsoft.AspNetCore.Mvc;
using PaintServer.DTO;
using PaintServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Controllers
{
    [ApiController]
    [Route("auth")]
    public class RegistrationController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegistrationData userRegistrationData)
        {
            //1  Ilya Zhdaney  zhdaney @gmail.com QWE123qazQQ

            RegistrationResultData registrationResultData = new RegistrationService().RegisterUser(userRegistrationData);

            return Ok(registrationResultData);
        }
    }
}
