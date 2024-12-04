using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class FinanceInfoData
    {
        #region 财务类型
        /// <summary>
        /// 收费类型
        /// </summary>
        public static DataTable DTChargeType { get; set; }


        /// <summary>
        /// 标记类型
        /// </summary>
        public static DataTable DTTabType { get; set; }

        #endregion 财务类型
    }
}
