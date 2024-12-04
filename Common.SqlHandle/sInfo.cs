using System;

namespace Common.SqlHandle
{
    public class sInfo
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserToken { get; set; }

        ///// <summary>
        ///// 方法名称
        ///// </summary>
        //public string MethodName { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        ///修改或添加字段(Columns1,Columns2)
        /// </summary>
        public string values { get; set; }
        /// <summary>
        /// 查询条件(Columns1='Columns1Values' and Columns2='Columns2Values')
        /// </summary>
        public string wheres { get; set; }

        /// <summary>
        /// 分组字段(Columns1,Columns2)需配置对应DataValues参数；
        /// </summary>
        public string GroupColumns { get; set; }


        /// <summary>
        /// 排序条件(Columns1,Columns2)默认增序 后缀DESC为倒序;
        /// </summary>
        public string OrderColumns { get; set; }

        private int showNO;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get { return showNO; } set { if (value == null) { showNO = 0; } else { showNO = Convert.ToInt32(value); } } }

    }
}
