using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class GetFilesListResultData
    {
        public bool GetFilesListResult { get; set; }
        public string GetFilesListResultMessage { get; set; }
        public List<SavedFileInfo> SavedFileInfo { get; set; }

        public GetFilesListResultData()
        {
            SavedFileInfo = new List<SavedFileInfo>();
        }
    }
}
