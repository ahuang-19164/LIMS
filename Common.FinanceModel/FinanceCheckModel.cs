using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FinanceModel
{
    #region

    /// <summary>
    /// 查询审核信息
    /// </summary>
    public class SelectFinanceCheckModel
    {

        /// <summary>
        /// 审核单号
        /// </summary>
        public string checkNo { get; set; }

        /// <summary>
        /// 医院编码集合
        /// </summary>
        public List<string> ListClientCodes { get; set; }


        /// <summary>
        /// 样本信息集合
        /// </summary>
        public List<string> ListFinanceID { get; set; }
        /// <summary>
        /// 物流接收起始时间
        /// </summary>
        public string operatTimeStart { get; set; }
        /// <summary>
        /// 物流接收结束时间
        /// </summary>
        public string operatTimeEnd { get; set; }
    }

    /// <summary>
    /// 审核账单信息
    /// </summary>
    public class FinanceCheckInfoModel
    {
        /// <summary>
        /// 审核单号
        /// </summary>
        public string checkNo { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public string clientNO { get; set; }


        /// <summary>
        /// 样本信息集合
        /// </summary>
        public List<string> ListFinanceID { get; set; }
        /// <summary>
        /// 物流接收起始时间
        /// </summary>
        public string operatTimeStart { get; set; }
        /// <summary>
        /// 物流接收结束时间
        /// </summary>
        public string operatTimeEnd { get; set; }
    }

    #endregion
}
