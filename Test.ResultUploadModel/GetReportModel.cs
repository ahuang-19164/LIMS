using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ResultUploadModel
{
    public class GetReportModel
    {
        public string userName { get; set; }
        public string userToken { get; set; }
        public string ClientPower { get; set; }
        public List<int> infoID { get; set; }
    }
}
