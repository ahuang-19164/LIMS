using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportTool.Model
{
    public class LoadInfo
    {
        /// <summary>
        /// 用户账户
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        public string UserToken { get; set; }
    }
}
