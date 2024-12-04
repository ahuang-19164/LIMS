using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestModel.Result
{
    /// <summary>
    /// 常规检验信息
    /// </summary>
    public class TestInfoModel
    {
        /// <summary>
        /// 样本信息ID
        /// </summary>
        public int perid { get; set; } = 0;
        /// <summary>
        /// 检验信息ID
        /// </summary>
        public int testid { get; set; } = 0;
        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 结果集合
        /// </summary>
        public List<ItemResultModel> ListResult { get; set; }

    }
    /// <summary>
    /// 常规结果信息
    /// </summary>
    public class ItemResultModel
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
