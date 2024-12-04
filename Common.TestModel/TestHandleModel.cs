using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestModel
{
    /// <summary>
    /// 检验人员信息
    /// </summary>
    public class GetTestInfoModel
    {
        /// <summary>
        /// 请求用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 请求密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public List<string> barcode { get; set; }
        /// <summary>
        /// 架子号
        /// </summary>
        public string frameNo { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string GroupNO { get; set; }
        /// <summary>
        /// 样本检测状态
        /// </summary>
        public string TestStateNO { get; set; }

        public string FlowNO { get; set; } = "";


    }

    /// <summary>
    /// 检验项目信息
    /// </summary>
    public class GetItemInfoModel
    {
        /// <summary>
        /// 请求用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 请求密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 样本id
        /// </summary>
        public string Testid { get; set; }
        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";

        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string GroupNO { get; set; }
        /// <summary>
        /// 工作流编号
        /// </summary>
        public string FlowNO { get; set; }
        /// <summary>
        /// 结果状态 0.正常.1.委托
        /// </summary>
        //public int ResultState { get; set; } = 0;
    }

    /// <summary>
    /// 提交检验项目信息
    /// </summary>
    public class TesthandleModel
    {
        public int id { get; set; } = 0;
        public int perid { get; set; } = 0;
        public int testid { get; set; } = 0;
        /// <summary>
        /// true 正常处理；false取消处理
        /// </summary>
        public bool infoState { get; set; }
        public string barcode { get; set; }
        public bool dstate { get; set; }
        public bool state { get; set; }
        public DateTime handleTime { get; set; }
        public DateTime createTime { get; set; }

        public string contact { get; set; }
        public string creater { get; set; }
        public string handler { get; set; }
        public string applyCodes { get; set; }
        public string applyNames { get; set; }
        public string groupCodes { get; set; }
        public string groupNames { get; set; }
        public string contactMode { get; set; }
        public string handleResult { get; set; }
        public string handleTypeNO { get; set; }

        public string pleasLevel { get; set; }
        public string recordTypeNO { get; set; }
        public string recordValue { get; set; }
        public string remark { get; set; }
        public string submitItemCodes { get; set; }
        public string submitItemNames { get; set; }

        //public bit state { get; set; }
    }

    /// <summary>
    /// 检验项目相关文件下载
    /// </summary>
    public class TestDownModel
    {
        /// <summary>
        /// 下载文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 1.流程文件（xml） 2.图片文件
        /// </summary>
        public string fileType { get; set; }
        /// <summary>
        /// 文档名称（数据库表名称）
        /// </summary>
        public string dirname { get; set; }

        /// <summary>
        /// 文件内容字符串
        /// </summary>
        public string fileString { get; set; }

    }
}
