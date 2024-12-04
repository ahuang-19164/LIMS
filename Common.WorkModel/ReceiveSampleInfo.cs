namespace Common.WorkModel
{
    public class ReceiveSampleInfo
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
        /// 样本ID号
        /// </summary>
        public string TestID { get; set; }
        /// <summary>
        /// 标本样本号
        /// </summary>
        public string SampleID { get; set; }
        /// <summary>
        /// 标本条码号
        /// </summary>
        public string SampleBarcode { get; set; }
        /// <summary>
        /// 接收到时间
        /// </summary>
        public string ReachTime { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string GroupNO { get; set; }
    }
}
