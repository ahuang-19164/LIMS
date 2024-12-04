using System.Collections.Generic;

namespace Common.ResultInfoModel
{
    public class ReInfo<T>
    {
        /// <summary>
        /// 返回信息编号0-返回报错1-返回成功2-返回正常失败。
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 返回信息内容
        /// </summary>
        public List<T> infos { get; set; }
        /// <summary>
        /// 返回附加信息
        /// </summary>
        public string msg { get; set; }
    }
}