using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PerModel
{
    /// <summary>
    /// 样本信息查询
    /// </summary>
    public class EntrySelectModel
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
        /// 操作类型(1个人2全部)
        /// </summary>
        public string operatType { get; set; }
        /// <summary>
        /// 样本状态（0全部）
        /// </summary>
        public int? sampleState { get; set; } = 0;
        /// <summary>
        /// 查询表名
        /// </summary>
        public string tableName { get; set; }
        ///// <summary>
        ///// 起始时间
        ///// </summary>
        //public string MethodName { get; set; }
        public string startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 样本登记号
        /// </summary>
        public string sampleCode { get; set; }

    }



    #region 客户端录入
    /// <summary>
    /// 录入信息
    /// </summary>
    public class EntryInfoModel
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
        /// 0,系统信息，1微信数据库，2，接口数据库
        /// </summary>
        public int connType { get; set; } = 0;
        /// <summary>
        /// 操作类型(1新增2编辑)
        /// </summary>
        public int operatType { get; set; }
        /// <summary>
        /// 1.个人修改，2.批量修改
        /// </summary>
        public int editType { get; set; } = 1;

        ///// <summary>
        ///// 方法名称
        ///// </summary>
        //public string MethodName { get; set; }
        public List<SampleInfoModel> sampleInfos { get; set; }
    }

    /// <summary>
    /// 录入样本信息
    /// </summary>
    public class SampleInfoModel
    {
        //string SsampleID;
        //string Sbarcode;
        //string Shospital;
        //string ShospitalName;
        //string SApplyCodes;
        //string SApplyNames;
        //string SfileString;

        /// <summary>
        /// 0,系统信息，1微信数据库，2，接口数据库
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 录入样本编号
        /// </summary>
        public string perid { get; set; }

        /// <summary>
        /// 检验中样本编号
        /// </summary>
        public string testid { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public string hospital { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string hospitalName { get; set; }

        /// <summary>
        /// 样本图片
        /// </summary>
        public string fileString { get; set; }


        /// <summary>
        /// 样本信息键值对
        /// </summary>
        public List<PairsInfoModel> pairsInfo { get; set; }
        /// <summary>
        /// 样本其他信息
        /// </summary>
        public List<PairsInfoModel> pairsOhterInfo { get; set; }
        /// <summary>
        /// 样本项目信息
        /// </summary>
        public string applyCodes { get; set; } = "";
        /// <summary>
        /// 样本项目名称
        /// </summary>
        public string applyNames { get; set; } = "";
    }
    /// <summary>
    /// 信息键值对
    /// </summary>
    public class PairsInfoModel
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string columnName { get; set; }
        /// <summary>
        /// 字段内容
        /// </summary>
        public object valueString { get; set; }
        /// <summary>
        /// 字段标题
        /// </summary>
        public string caption { get; set; }

    }

    #endregion

    #region 疾控信息录入
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

    #region 微信信息录入
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


    #endregion
}
