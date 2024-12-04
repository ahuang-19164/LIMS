using System;

namespace Common.SqlHandle
{
    public class sSetValue
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        ///修改或添加字段(Columns1,Columns2)
        /// </summary>
        public string SelectValues { get; set; }
        /// <summary>
        /// 查询条件(Columns1='Columns1Values' and Columns2='Columns2Values')
        /// </summary>
        public string WhereValues { get; set; }

        /// <summary>
        /// 分组字段(Columns1,Columns2)需配置对应DataValues参数；
        /// </summary>
        public string GroupColumns { get; set; }


        /// <summary>
        /// 排序条件(Columns1,Columns2)默认增序 后缀DESC为倒序;
        /// </summary>
        public string OrderColumns { get; set; }


        private int DID;
        /// <summary>
        /// 删除必须指定ID
        /// </summary>
        public int? DataValueID { get { return DID; } set { if (value == null) { DID = 0; } else { DID = Convert.ToInt32(value); } } }


        /// <summary>
        /// 弹出提示窗体
        /// </summary>
        public int MessageShow { get; set; }
    }
}
