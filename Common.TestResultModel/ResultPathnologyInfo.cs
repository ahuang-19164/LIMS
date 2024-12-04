namespace Common.TestResultModel
{
    public class ResultPathnologyInfo
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
        /// 项目流程编号
        /// </summary>
        public string testFlowNO { get; set; }
        /// <summary>
        /// 组织病理结果
        /// </summary>
        public ResultPathnology ResultInfo { get; set; }

        /// <summary>
        /// 报告审核信息
        /// </summary>
        public AutographInfo AutographInfo { get; set; }




    }
}
