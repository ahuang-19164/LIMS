namespace workOther.ItemHandle
{
    public class ReturnInfo
    {
        /// <summary>
        /// 样本状态
        /// </summary>
        public object testStateNO { get; set; } = 0;
        /// <summary>
        /// 处理状态
        /// </summary>
        public object handleTypeNO { get; set; } = 0;
        /// <summary>
        /// 处理结果描述
        /// </summary>
        public object handleResult { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public object handler { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public object handleTime { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public object remark { get; set; }

        /// <summary>
        /// 同意状态
        /// </summary>
        public bool state { get; set; } = false;


        public string msg { get; set; }


    }
}
