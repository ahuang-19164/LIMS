using System.Collections.Generic;

namespace Common.SqlHandle
{
    public class sSetInfo
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
        /// 多重查询信息
        /// </summary>
        public List<sSetValue> SelectSet { get; set; }
    }
}
