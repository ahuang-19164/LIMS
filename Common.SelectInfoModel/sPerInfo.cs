using System.Collections.Generic;

namespace Finance.InfoModels
{
    public class sPerInfo
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
        /// 查询信息键值对
        /// </summary>
        public List<PairsInfo> PairsInfo { get; set; }
        /// <summary>
        /// 采样起始时间
        /// </summary>
        public string sampleTimeStart { get; set; }
        /// <summary>
        /// 采样起始结束
        /// </summary>
        public string sampleTimeEnd { get; set; }
        /// <summary>
        /// 物流接收起始时间
        /// </summary>
        public string receiveTimeStart { get; set; }
        /// <summary>
        /// 物流接收结束时间
        /// </summary>
        public string receiveTimeEnd { get; set; }
        /// <summary>
        /// 录入起始时间
        /// </summary>
        public string perTimeStart { get; set; }
        /// <summary>
        /// 录入结束时间
        /// </summary>
        public string perTimeEnd { get; set; }

    }
    public class PairsInfo
    {


        /// <summary>
        /// 字段名称
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        ///查询类型 0，=||1,in||2，like||3，<||4，>||5，<=||6，>=
        /// </summary>
        public string type { get; set; }


        /// <summary>
        /// 查询id
        /// </summary>
        public string keyNO { get; set; }
        /// <summary>
        /// 查询值
        /// </summary>
        public string keyValue { get; set; }
    }
}
