using Microsoft.AspNetCore.Mvc;
using PaintServer.DTO;
using System.Net;
using PaintServer.Services;

namespace PaintServer.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController: ControllerBase
    {
        private IAutorizationService _autorizationService;
        public LoginController(IAutorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }

            [HttpPost]
            [Route("login")]
            public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
            {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ
            
            //AutorizationResultData autorizationResultData = new AutorizationService().AutorizeUser(userAutorizationData);
            AutorizationResultData autorizationResultData = _autorizationService.AutorizeUser(userAutorizationData);

                return Ok(autorizationResultData);
            }
    }
}
