using Microsoft.AspNetCore.Mvc;
using PaintServer.DTO;
using PaintServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.DAL;
using PaintServer.Exeptions;
namespace PaintServer.Controllers
{
    [ApiController]
    [Route("auth")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegistrationData userRegistrationData)
        {
            //1  Ilya Zhdaney  zhdaney @gmail.com QWE123qazQQ

            
            //RegistrationResultData registrationResultData = new RegistrationService().RegisterUser(userRegistrationData);
            RegistrationResultData registrationResultData = _registrationService.RegisterUser(userRegistrationData);

            return Ok(registrationResultData);
        }
    }
}
