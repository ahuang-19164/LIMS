

using System;

namespace Common.SystemModel
{
    /// <summary>
    /// 样本操作记录
    /// </summary>
    public class comm_samplerecord
    {
        public comm_samplerecord()
        {


        }
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Desc:申请ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string perid { get; set; }

        /// <summary>
        /// Desc:检验ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string testid { get; set; }

        /// <summary>
        /// Desc:条码号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string barcode { get; set; }

        /// <summary>
        /// Desc:操作类型
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string operatType { get; set; }

        /// <summary>
        /// Desc:记录内容
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string record { get; set; }

        /// <summary>
        /// Desc:原因
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string reason { get; set; }

        /// <summary>
        /// Desc:操作人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string operater { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime createTime { get; set; }

        /// <summary>
        /// Desc:是否展示给客户
        /// Default:
        /// Nullable:True
        /// </summary>           
        public bool clientShow { get; set; }
    }
}
