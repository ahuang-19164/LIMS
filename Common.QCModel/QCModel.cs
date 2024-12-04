using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QCModel
{
    /// <summary>
    /// 新增QC信息
    /// </summary>
    public class QCAddModel
    {
        public bool dstate { get; set; }
        public bool resultState { get; set; }
        public bool state { get; set; }
        //public DateTime createTime { get; set; }
        public string qcTime { get; set; }
        public int id { get; set; }
        public int sort { get; set; } = 0;
        //public string creater { get; set; }
        public string itemNO { get; set; }
        public string itemResult { get; set; }
        public string planGradeid { get; set; }
        public string planid { get; set; }
        public string planItemid { get; set; }
        public string remark { get; set; }
        public string resultRule { get; set; }
        public string resultType { get; set; }
        public string zVlaue { get; set; }
    }
    /// <summary>
    /// QC信息查询
    /// </summary>
    public class QCSelectModel
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
        /// 返回信息内容
        /// </summary>
        public QCSelectValueModel info { get; set; }
        /// <summary>
        /// 提交信息状态
        /// </summary>cvb ,smx
        public int state { get; set; }
    }
    /// <summary>
    /// 查询QC相关信息
    /// </summary>
    public class QCSelectValueModel
    {
        public string planid { get; set; }
        public string planGradeid { get; set; }
        public string planItemid { get; set; }
        public string itemNO { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
