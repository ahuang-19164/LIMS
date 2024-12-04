using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    /// <summary>
    /// 存储库缓存类型
    /// </summary>
    public class SWCommData
    {
        #region 存储库类型


        /// <summary>
        /// 储存库状态
        /// </summary>
        public static DataTable DTStoresType { get; set; }

        /// <summary>
        /// 标本架状态
        /// </summary>
        public static DataTable DTShelfType { get; set; }

        /// <summary>
        /// 标本状态
        /// </summary>
        public static DataTable DTRecordType { get; set; }

        #endregion
    }
}
