using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ManageModel
{
    /// <summary>
    /// 其他检验信息查询
    /// </summary>
    public class ManageInfoModel
    {
        /// <summary>
        /// 请求用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 请求密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 样本姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 样本条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.Now.AddDays(-1);
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 0为查询委托信息，1为查询免疫组化信息
        /// </summary>
        public int sState { get; set; } = 0;
    }
}
