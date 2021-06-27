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
    public class GetFilesListController : ControllerBase
    {
        [HttpPost]
        [Route("getsavedfileslist")]
        public IActionResult Load([FromBody] GetFilesListInfo getFilesListInfo)
        {

            GetFilesListResultData getFilesListResultData = new GetFilesListService().GetFilesList(getFilesListInfo);

            return Ok(getFilesListResultData);
        }
    }
}
