using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.SqlModel
{

    /// <summary>
    /// 增加数据
    /// </summary>
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

        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get; set; } = 0;

    }
    /// <summary>
    /// 修改数据
    /// </summary>
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
        /// 0,系统信息，1微信数据库，2，接口数据库
        /// </summary>
        public int ConnType { get; set; } = 0;

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        ///修改内容(Columns1="Columns1Value",Columns1="Columns1Value")
        /// </summary>
        public string value { get; set; }


        /// <summary>
        ///修改内容(Columns1="Columns1Value",Columns1="Columns1Value")
        /// </summary>
        public Dictionary<string, object> values { get; set; }
        /// <summary>
        /// 查询条件(Columns1='Columns1Values' and Columns2='Columns2Values')
        /// </summary>
        public string wheres { get; set; }
        /// <summary>
        /// 增，删，改，差单个指定数据赋值数据ID值（删除必须指定ID）
        /// </summary>
        public int? DataValueID { get; set; } = 0;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get; set; } = 0;

    }
    /// <summary>
    /// 查询数据
    /// </summary>
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

        /// <summary>
        /// 0,系统信息，1微信数据库，2，接口数据库
        /// </summary>
        public int ConnType { get; set; } = 0;
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
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get; set; } = 0;

    }
    /// <summary>
    /// 删除数据
    /// </summary>
    public class dInfo
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
        /// 删除必须指定ID
        /// </summary>
        public int? DataValueID { get; set; } = 0;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get; set; } = 0;

    }
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
        /// <summary>
        /// 隐藏指定ID
        /// </summary>
        public int? DataValueID { get; set; } = 0;
        /// <summary>
        /// 弹出提示窗体：0显示状态，1隐藏状态
        /// </summary>
        public int? MessageShow { get; set; } = 0;
    }


    public class SaveTableInfo
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
        /// 更新DataTable表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 更新DataTable表内容
        /// </summary>
        public DataTable DT { get; set; }
    }

}
