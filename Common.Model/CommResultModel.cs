using Common.TestModel.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// 通用结果保存信息
    /// </summary>
    public class CommResultModel<T>
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 结果结果状态 1.检验者 2.复初审者 3.审核者
        /// </summary>
        public int ResultState { get; set; }
        /// <summary>
        /// 专业组名称
        /// </summary>
        public string groupName { get; set; }
        /// <summary>
        /// 项目流程编号
        /// </summary>
        public string testFlowNO { get; set; }
        /// <summary>
        /// 结果信息
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 报告审核信息
        /// </summary>
        public AutographInfo AutographInfo { get; set; }
    }
}
