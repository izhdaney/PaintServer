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
        private IDeleteImageService _deleteImageService;

        public DeleteImageController(IDeleteImageService deleteImageService)
        {
            _deleteImageService = deleteImageService;
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Load([FromBody] DeleteImageInfo deleteImageInfo)
        {

            
            /*        DeleteImageResultData deleteImageResultData = new DeleteImageService().DeleteImage(deleteImageInfo);*/
            DeleteImageResultData deleteImageResultData = _deleteImageService.DeleteImage(deleteImageInfo);
            return Ok(deleteImageResultData);
        }
    }
}
