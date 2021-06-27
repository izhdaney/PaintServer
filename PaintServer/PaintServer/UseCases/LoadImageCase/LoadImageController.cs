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
    public class LoadImageController : ControllerBase
    {
            [HttpPost]
            [Route("load")]
            public IActionResult Load([FromBody] LoadImageInfo loadImageInfo)
            {

                LoadImageResultData loadImageResultData = new LoadImageService().LoadImage(loadImageInfo);

                return Ok(loadImageResultData);
            }
    }
}
