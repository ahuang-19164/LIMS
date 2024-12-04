using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// 公用api返回信息对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WebApiCallBack
    {
        /// <summary>
        /// 方法说明
        /// </summary>
        public string methodDescription { get; set; }
        /// <summary>
        /// 返回其他信息
        /// </summary>
        public object otherData { get; set; }
        /// <summary>
        /// 返回状态
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 0 访问成功  1 访问失败  其他：保存信息
        /// </summary>
        public int code { get; set; } = 1;
    }
}
