using System;

namespace Common.SqlHandle
{
    /// <summary>
    /// 隐藏数据
    /// </summary>
    public class hideInfo
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
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        private int DID;
        /// <summary>
        /// 隐藏指定ID
        /// </summary>
        public int? DataValueID { get { return DID; } set { if (value == null) { DID = 0; } else { DID = Convert.ToInt32(value); } } }

        private int showNO;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get { return showNO; } set { if (value == null) { showNO = 0; } else { showNO = Convert.ToInt32(value); } } }
    }
}
