using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.DataHandle
{
    public class SqlType
    {
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<SqlData> Datas { get; set; }
    }
}
