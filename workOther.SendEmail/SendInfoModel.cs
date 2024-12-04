using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workOther.SendEmail
{
    public class InfoModel<T>
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
    public class sampleInfo
    {
        public int perid { get; set; }
        public int testid { get; set; }
        public string barcode { get; set; }

        public string email { get; set; }
    }
}
