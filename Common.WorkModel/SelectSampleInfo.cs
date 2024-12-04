using System.Collections.Generic;

namespace Common.WorkModel
{
    public class SelectTestInfo
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
    public class selectTestResultInfo
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
}
