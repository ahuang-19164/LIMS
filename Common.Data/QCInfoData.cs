using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class QCInfoData
    {
        /// <summary>
        /// 规则类型
        /// </summary>
        public static DataTable DTRuleClass { get; set; }
        /// <summary>
        /// 规则
        /// </summary>
        public static DataTable DTRuleQC { get; set; }
        /// <summary>
        /// 组合规则
        /// </summary>
        public static DataTable DTRuleGroup { get; set; }
        /// <summary>
        /// 计划
        /// </summary>
        public static DataTable DTQCPlan { get; set; }
        /// <summary>
        /// 质控品
        /// </summary>
        public static DataTable DTQCGrade { get; set; }
        public static DataTable DTQCBatch { get; set; }












        /// <summary>
        /// 结果判断类型
        /// </summary>
        public static DataTable DTCriteriaType { get; set; }
        /// <summary>
        /// 判定状态
        /// </summary>
        public static DataTable DTEerrorType { get; set; }
        /// <summary>
        /// 规则范围
        /// </summary>
        public static DataTable DTRangType { get; set; }

        /// <summary>
        /// 质控水平
        /// </summary>
        public static DataTable DTQCLevel { get; set; }
    }
}
