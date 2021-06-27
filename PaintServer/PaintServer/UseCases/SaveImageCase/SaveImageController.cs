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
    [Route("operation")]
    public class SaveImageController : ControllerBase
    {

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] SaveImageInfo saveImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney @gmail.com QWE123qazQQ

            SaveImageResultData saveImageResultData = new SaveImageService().SaveImage(saveImageInfo);

            return Ok(saveImageResultData);
        }
    }
}
