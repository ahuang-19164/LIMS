using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PerModel
{
    /// <summary>
    /// 删除信息
    /// </summary>
    public class DeleteInfoModel
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
        /// 0.系统接收，1，微信接收，2，A接口接收
        /// </summary>
        public int checkType { get; set; } = 0;
        /// <summary>
        /// 样本删除状态（1.前处理删除，2.审核删除，3.检验删除）
        /// </summary>

        public int state { get; set; }
        /// <summary>
        /// 删除样本信息列表
        /// </summary>

        public List<InfoListModel> sampleinfos { get; set; }






    }
    /// <summary>
    /// 删除样本信息对象
    /// </summary>
    public class InfoListModel
    {
        /// <summary>
        /// 样本号
        /// </summary>
        public string SampleID { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
    }
}
