using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    //基础信息维护对象
    public class BaseModel<T>
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string tableName { get; set; }
        /// <summary>
        /// 操作类型 0 查询 1新增 2编辑 3隐藏  4 删除
        /// </summary>
        public int operateType { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        public T Value { get; set; }
    }
}
