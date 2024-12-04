using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestModel
{
    /// <summary>
    /// 提交检验中样本信息
    /// </summary>
    public class TestWorkModel
    {
        /// <summary>
        /// 检验中样本ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 样本条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 检验编号
        /// </summary>
        public string testNo { get; set; }
        /// <summary>
        /// 试管架号
        /// </summary>
        public string frameNo { get; set; }
        /// <summary>
        /// 样本专业组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        /// 样本流程编号
        /// </summary>
        public string flowNO { get; set; }
    }
}
