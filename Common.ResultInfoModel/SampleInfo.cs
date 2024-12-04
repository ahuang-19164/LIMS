namespace Common.ResultInfoModel
{
    public class SampleInfo
    {
        /// <summary>
        /// 样本编号
        /// </summary>
        public string sampleID { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 信息执行结果0失败1成功
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 条码号任务执行状态
        /// </summary>
        public string codeMsg { get; set; }
    }
}
