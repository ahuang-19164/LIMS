using System;
using System.Collections.Generic;

namespace Common.SqlHandle
{
    public class uInfo
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
        /// <summary>
        ///修改内容(Columns1="Columns1Value",Columns1="Columns1Value")
        /// </summary>
        public string value { get; set; }


        private Dictionary<string, object> Dr;
        /// <summary>
        ///修改内容(Columns1="Columns1Value",Columns1="Columns1Value")
        /// </summary>
        public Dictionary<string, object> values { get; set; }


        /// <summary>
        /// 查询条件(Columns1='Columns1Values' and Columns2='Columns2Values')
        /// </summary>
        public string wheres { get; set; }

        private int DID;
        /// <summary>
        /// 增，删，改，差单个指定数据赋值数据ID值（删除必须指定ID）
        /// </summary>
        public int? DataValueID { get { return DID; } set { if (value == null) { DID = 0; } else { DID = Convert.ToInt32(value); } } }
        private int showNO;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get { return showNO; } set { if (value == null) { showNO = 0; } else { showNO = Convert.ToInt32(value); } } }

    }
}
