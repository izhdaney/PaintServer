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

    public class StatisticController:ControllerBase
    {
        private IStatisticService _statisticService;
        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }


        [HttpPost]
        [Route("getuserstatistic")]
        public IActionResult Load([FromBody] StatisticInfo statisticInfo)
        {

            /* GetFilesListResultData getFilesListResultData = new GetFilesListService().GetFilesList(getFilesListInfo);*/
            StatisticResultData statisticResultData = _statisticService.GetUserStatistics(statisticInfo);

            return Ok(statisticResultData);
        }
    }
}
