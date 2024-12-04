using System.Data;

namespace Common.SqlHandle
{
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
