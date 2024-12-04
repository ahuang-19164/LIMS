using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ResultUploadModel
{
    public class UpLoadReportModel
    {
        public string userName { get; set; }
        public string userToken { get; set; }
        /// <summary>
        /// 0,上传操作，1清空操作
        /// </summary>
        public int upState { get; set; } = 0;


        public int perid { get; set; }
        public int testid { get; set; }
        public string barcode { get; set; }
        public string hospitalNo { get; set; }
        public string FileName { get; set; }
        public string FileString { get; set; }
    }
}
