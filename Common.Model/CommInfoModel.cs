using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class commInfoModel<T>
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
        /// 返回信息内容
        /// </summary>
        public List<T> infos { get; set; }
        /// <summary>
        /// 提交信息状态
        /// </summary>
        public int state { get; set; }
    }
}
