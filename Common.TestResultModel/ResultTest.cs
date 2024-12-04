using System;
using System.Collections.Generic;

namespace Common.TestResultModel
{
    public class ResultTest
    {
        public string groupNO { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 样本ID
        /// </summary>
        public int testid { get; set; }=0;
        public int perid { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public List<ItemResult> ListResult { get; set; }

    }
    public class ItemResult
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string itemCode { get; set; }
        /// <summary>
        /// 项目结果
        /// </summary>
        public string itemResult { get; set; }
        /// <summary>
        /// 项目提示
        /// </summary>
        public string itemFlag { get; set; }
        /// <summary>
        /// 报告显示状态
        /// </summary>
        public string itemReportState { get; set; }
        /// <summary>
        /// 允许为空
        /// </summary>
        //public string resultNullState { get; set; }
        /// <summary>
        /// 项目排序
        /// </summary>
        public int itemSort { get; set; }


    }
}
