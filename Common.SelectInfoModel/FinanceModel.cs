using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.InfoModels
{
    #region 发送信息类
    /// <summary>
    /// 发送信息类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class sendModel<T>
    {
        public string userName { get; set; }
        public string userToken { get; set; }

        public List<T> infos { get; set; }
    }

    public class priceChange
    {
        public string financeID { get; set; }
        public string barcode { get; set; }
        public string charge { get; set; }
    }
    #endregion



    #region 返回信息类
    public class returnMode<T>
    {
        /// <summary>
        /// 返回信息编号0-返回报错1-返回成功2-返回正常失败。
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回信息内容
        /// </summary>
        public List<T> infos { get; set; }
        /// <summary>
        /// 返回附加信息
        /// </summary>
        public string msg { get; set; }
    }
    public class returnSampleState
    {
        /// <summary>
        /// 样本编号
        /// </summary>
        public string sampleID { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 信息执行结果0失败1成功
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 条码号任务执行状态
        /// </summary>
        public string codeMsg { get; set; }
    }

    #endregion

}
