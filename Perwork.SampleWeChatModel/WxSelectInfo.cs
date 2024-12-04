using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perwork.SampleWeChatModel
{

    /// <summary>
    /// 样本信息查询
    /// </summary>
    public class WxSelectModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 操作类型(0编码查询，1个人，2全部)
        /// </summary>
        public string operatType { get; set; }
        /// <summary>
        /// 样本状态（0全部）
        /// </summary>
        public int? sampleState { get; set; } = 0;
        /// <summary>
        /// 查询表名
        /// </summary>
        public string tableName { get; set; }
        ///// <summary>
        ///// 起始时间
        ///// </summary>
        //public string MethodName { get; set; }
        public string startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 样本登记号
        /// </summary>
        public string sampleCode { get; set; }

    }

}
