using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.jikongModel
{
    public class WxEntryModel
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
        /// 检验接收信息集合
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 接收架子号
        /// </summary>
        public string frameNo { get; set; }



    }
}
