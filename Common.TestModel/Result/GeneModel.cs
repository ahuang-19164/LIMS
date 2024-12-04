using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestModel.Result
{
    /// <summary>
    /// 基因检测结果对象
    /// </summary>
    public class GeneInfoModel
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
        public List<GeneItemModel> ListResult { get; set; }

    }
    /// <summary>
    /// 基因项目对象
    /// </summary>
    public class GeneItemModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string itemCode { get; set; }
        /// <summary>
        /// 项目结果
        /// </summary>
        public List<GeneResultModel> itemResults { get; set; }
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
    /// <summary>
    /// 基因结果对象
    /// </summary>
    public class GeneResultModel
    {
        /// <summary>
        /// 结果字段值
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 结果名称
        /// </summary>
        public string names { get; set; }
        /// <summary>
        /// 结果值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 图片字符串
        /// </summary>
        public string imgstring { get; set; }
    }
}
