using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class OtherInfoData
    {
        /// <summary>
        /// 样本委托状态
        /// </summary>
        public static DataTable DTDelegateState { get; set; }


        /// <summary>
        /// 样本提交状态
        /// </summary>
        public static DataTable DTSubmitState { get; set; }
        /// <summary>
        /// 提交信息处理状态
        /// </summary>
        public static DataTable DTHandleState { get; set; }


        /// <summary>
        /// 服务类型状态
        /// </summary>
        public static DataTable DTServeState { get; set; }


    }
}
