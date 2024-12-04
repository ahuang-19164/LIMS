using System;
using System.Collections.Generic;

namespace Common.SqlHandle
{
    public class iInfo
    {        /// <summary>
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
        /// <summary>
        /// 插入一条数据
        /// </summary>
        public Dictionary<string, object> values { get; set; }


        /// <summary>
        ///批量插入声明字段名称集合
        /// </summary>
        public Dictionary<string, List<object>> listValues { get; set; }

        private int showNO;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get { return showNO; } set { if (value == null) { showNO = 0; } else { showNO = Convert.ToInt32(value); } } }

    }
}
