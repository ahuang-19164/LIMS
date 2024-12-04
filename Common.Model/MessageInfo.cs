namespace Common.Model
{
    public class GetMessageInfo
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserToken { get; set; }
        public int userNO { get; set; }
        public string userRole { get; set; }
    }
    public class ReMessageInfo
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public int id { get; set; } = 0;
        /// <summary>
        /// 条码信息
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 信息类型
        /// </summary>
        public string stateNo { get; set; }
        /// <summary>
        /// 信息类型名称
        /// </summary>
        public string stateName { get; set; }
        /// <summary>
        /// 信息内容
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 信息创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public int state { get; set; }
    }
}
