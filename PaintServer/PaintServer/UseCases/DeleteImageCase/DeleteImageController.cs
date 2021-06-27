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
    public class DeleteImageController : ControllerBase
    {
        [HttpPost]
        [Route("delete")]
        public IActionResult Load([FromBody] DeleteImageInfo deleteImageInfo)
        {

            
            DeleteImageResultData deleteImageResultData = new DeleteImageService().DeleteImage(deleteImageInfo);

            return Ok(deleteImageResultData);
        }
    }
}
