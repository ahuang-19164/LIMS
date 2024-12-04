using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.WorkModel
{
    public class TestModel
    {
    }
    /// <summary>
    /// 获取标本结果信息
    /// </summary>
    public class selectTestResultInfo
    {
        /// <summary>
        /// 请求用户名
        /// </summary>
        public string userName { get; set; }
        //请求密钥
        public string userToken { get; set; }
        /// <summary>
        /// 样本信息id
        /// </summary>
        public string testid { get; set; }
        /// <summary>
        /// 样本信息条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 样本信息流程编号
        /// </summary>
        public string flowNO { get; set; }
        /// <summary>
        /// 样本信息组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        /// 查询样本信息状态0，常规查询样本结果信息。1，查询委托样本结果信息
        /// </summary>
        public string selectState { get; set; }
    }
}
