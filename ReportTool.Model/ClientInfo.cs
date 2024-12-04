using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportTool.Model
{
    public class ClientInfo
    {
        public int id { get; set; } = 0;
        public string code { get; set; }
        public string name { get; set; }
        public string Token { get; set; }
        public string[] clientCodes { get; set; }
        public string[] Power { get; set; }
        public string remark { get; set; }
    }
}
