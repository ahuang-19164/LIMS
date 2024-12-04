using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.InfoModels
{
    public class sCheckInfo
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
        /// 医院编码集合
        /// </summary>
        public List<string> clientCodes { get; set; }
        /// <summary>
        /// 物流接收起始时间
        /// </summary>
        public string operatTimeStart { get; set; }
        /// <summary>
        /// 物流接收结束时间
        /// </summary>
        public string operatTimeEnd { get; set; }
    }
}
