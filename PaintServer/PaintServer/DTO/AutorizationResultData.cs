using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class AutorizationResultData
    {
        public int AutorizationResultCode { get; set; }
        public int UserId { get; set; }
        public string AutorizationResultMessage { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
