using System.Data;

namespace Common.Data
{
    public class ReportCommData
    {
        /// <summary>
        /// 报表类型表
        /// </summary>
        public static DataTable DTReportType { get; set; }
        /// <summary>
        /// 报表类型设置
        /// </summary>
        public static DataTable DTReportSet { get; set; }
        /// <summary>
        /// 报表信息表
        /// </summary>
        public static DataTable DTReportBindInfo { get; set; }
        /// <summary>
        /// 报表数据表（报表数据报对应关系）
        /// </summary>
        public static DataTable DTReportSrouceInfo { get; set; }

    }
}
