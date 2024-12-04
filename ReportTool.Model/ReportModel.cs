using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportTool.Model
{
    /// <summary>
    /// 获取报告信息
    /// </summary>
    public class GetReportModel
    {
        public string userName { get; set; }
        public string userToken { get; set; }
        public string ClientPower { get; set; }
        /// <summary>
        /// 0.报告端查询，1，客户端查询
        /// </summary>
        public int reportType { get; set; } = 0;
        public List<int> infoID { get; set; }
    }
    /// <summary>
    /// 下载报告信息
    /// </summary>
    public class DownReportModel
    {
        public string userName { get; set; }
        public string userToken { get; set; }
        public string ClientPower { get; set; }
        /// <summary>
        /// 0.报告端查询，1，客户端查询
        /// </summary>
        public int reportType { get; set; } = 0;
        public int infoID { get; set; } = 0;

    }
}
