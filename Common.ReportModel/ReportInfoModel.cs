using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ReportModel
{
    /// <summary>
    /// 获取报告信息
    /// </summary>
    public class GetReportModel
    {
        public string UserName { get; set; }
        public string userToken { get; set; }
        public string ClientPower { get; set; }
        /// <summary>
        /// 0.报告端查询，1，客户端查询
        /// </summary>
        public int reportType { get; set; } = 0;
        public List<int> infoID { get; set; }
    }
    ///// <summary>
    ///// 下载报告信息
    ///// </summary>
    //public class DownReportModel
    //{
    //    public string userName { get; set; }
    //    public string userToken { get; set; }
    //    public string ClientPower { get; set; }
    //    /// <summary>
    //    /// 0.报告端查询，1，客户端查询
    //    /// </summary>
    //    public int reportType { get; set; } = 0;
    //    public int infoID { get; set; } = 0;

    //}

    /// <summary>
    /// 上传报告
    /// </summary>
    public class UpLoadReportModel
    {
        public string userName { get; set; }
        public string userToken { get; set; }
        /// <summary>
        /// 0,上传操作，1清空操作
        /// </summary>
        public int upState { get; set; } = 0;

        /// <summary>
        /// 录入id
        /// </summary>
        public int perid { get; set; }
        /// <summary>
        /// 检验id
        /// </summary>
        public int testid { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public string hospitalNo { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件string
        /// </summary>
        public string FileString { get; set; }
    }
}
