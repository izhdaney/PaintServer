using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class StatisticResultData
    {
        public bool StatisticResult { get; set; }
        public string StatisticResultMessage { get; set; }
        public List<StatisticItem> StatisticItems { get; set; }

        public StatisticResultData()
        {
            StatisticItems = new List<StatisticItem>();
        }
     
    }
}
