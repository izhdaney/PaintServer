using Microsoft.AspNetCore.Mvc;
using PaintServer.DTO;
using System.Net;

namespace PaintServer.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController: ControllerBase
    {

            [HttpPost]
            [Route("login")]
            public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
            {
            //1  Ilya Zhdaney  zhdaney @gmail.com QWE123qazQQ

            AutorizationResultData autorizationResultData = new AutorizationResultData()
            {
                UserID = 1,
                FirstName = "Ilya",
                LastName = "Zhdaney",
                Login = "zhdaney@gmail.com",
                AutorizationResultCode = 200
            };
                return Ok(autorizationResultData);
            }
    }
}
