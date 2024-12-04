using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FinanceModel
{
    /// <summary>
    /// 回款信息编辑
    /// </summary>
    public class FundInfoModel
    {

        /// <summary>
        /// 回款申请状态1为新增2为编辑
        /// </summary>
        public int fundState { get; set; } = 0;
        /// <summary>
        /// 删除状态
        /// </summary>
        public bool dstate { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool state { get; set; }
        /// <summary>
        /// 账单审核时间
        /// </summary>
        public DateTime checkTime { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime fundTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime operatTime { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal fundCharge { get; set; }
        /// <summary>
        /// 信息id
        /// </summary>
        public int id { get; set; } = 0;
        /// <summary>
        /// 操作人员
        /// </summary>
        public string operater { get; set; }
        /// <summary>
        /// 账单编号
        /// </summary>
        public string billNo { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string clientNO { get; set; }
        /// <summary>
        /// 账单id
        /// </summary>
        public int no { get; set; } = 0;
        /// <summary>
        /// 负责人
        /// </summary>
        public string person { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

    }
}
