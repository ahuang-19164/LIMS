using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jk.UpResultInfoModel
{
    public class UpResultModel
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
        /// 查询参数
        /// </summary>
        public GetInfo GetValueInfo { get; set;}
    }
    public class GetInfo
    {
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 客户条码
        /// </summary>
        public string hosbarcode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 上传状态0，全部，1，未上传，2已上传
        /// </summary>
        public string xgState { get; set; } = "0";
        /// <summary>
        /// 开始时间
        /// </summary>
        public string receiveStartTime { get; set; }
        /// <summary>
        ///结束时间
        /// </summary>
        public string receiveEndTime { get; set; }
    }
}
