using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.jikongModel
{
    #region 疾控信息录入
    /// <summary>
    /// 插入疾控信息
    /// </summary>
    public class JKEntryModel
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
        public List<JKSampleInfoModel> sampleinfos { get; set; }

    }
    /// <summary>
    /// 疾控空信息样本信息
    /// </summary>
    public class JKSampleInfoModel
    {
        public int id { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 外部条码
        /// </summary>
        public string hospitalBarcode { get; set; }
        /// <summary>
        /// 试管架号
        /// </summary>
        public string frameNo { get; set; } = "";
        /// <summary>
        /// 采样日期
        /// </summary>
        public string sampleTime { get; set; }
        /// <summary>
        /// 接收日期
        /// </summary>
        public string receiveTime { get; set; }
        /// <summary>
        /// 采样地点
        /// </summary>
        public string sampleLocation { get; set; }
        /// <summary>
        /// 样本类型
        /// </summary>
        public string sampleTypeNO { get; set; }
        /// <summary>
        /// 样本类型名称
        /// </summary>
        public string sampleTypeNames { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string creater { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string clientCode { get; set; }
        /// <summary>
        /// 客户客户名称
        /// </summary>
        public string clientName { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string applyCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string applyName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 性别编号1男2女3其他
        /// </summary>
        public string patientSexNO { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string patientSexNames { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string ageYear { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string patientPhone { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string patientCardNo { get; set; }
        /// <summary>
        /// 其他证件号
        /// </summary>
        public string passportNo { get; set; }
        /// <summary>
        /// 现居住地址
        /// </summary>
        public string patientAddress { get; set; }

        /// <summary>
        /// 采样状态 1单采 2混采
        /// </summary>
        public int sampleType { get; set; } = 0;

    }


    #endregion
}
